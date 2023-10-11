using AutoMapper;
using Bazaarr.Data.IRepositories;
using Bazaarr.Data.Repositories;
using Bazaarr.Domain.Models;
using Bazaarr.Service.DTOs.Cart;
using Bazaarr.Service.DTOs.Order;
using Bazaarr.Service.Exceptions;
using Bazaarr.Service.Interfaces;
using Bazaarr.Service.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Bazaarr.Service.Services;

public class OrderService : IOrderService
{
    private readonly IMapper mapper = MappingProfile.Initialize();
    private readonly IRepository<Order> orderRepository = new Repository<Order>();
    public async Task<OrderForResultDto> CreateAsync(OrderForCreationDto dto)
    {
        var order = await this.orderRepository.SelectAll()
            .FirstOrDefaultAsync(o => o.UserId == dto.UserId);
        if (order is not null)
            throw new CustomException(400, "Order is already exist");

        var mappedOrder = this.mapper.Map<Order>(dto);

        var insertedOrder = await this.orderRepository.InsertAsync(mappedOrder);

        return this.mapper.Map<OrderForResultDto>(insertedOrder);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var order = await this.orderRepository.SelectByIdAsync(id);
        if (order is null)
            throw new CustomException(404, "Order is not found");

        await this.orderRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<OrderForResultDto>> RetrieveAllAsync()
    {
        var orders = await this.orderRepository.SelectAll()
           .Include(o => o.User)
           .ToListAsync();

        if (orders is null)
            throw new CustomException(404, "Orders is not found");

        var mappedOrders = this.mapper.Map<IEnumerable<OrderForResultDto>>(orders);

        return mappedOrders;
    }

    public async Task<OrderForResultDto> RetrieveByIdAsync(long id)
    {
        var order = await this.orderRepository.SelectByIdAsync(id);
        if (order is null)
            throw new CustomException(404, "Order is not found");

        return this.mapper.Map<OrderForResultDto>(order);
    }

    public async Task<OrderForResultDto> UpdateAsync(OrderForUpdateDto dto)
    {
        var order = await this.orderRepository.SelectByIdAsync(dto.Id);
        if (order is null)
            throw new CustomException(404, "ORder is not found");

        var updatedOrder = this.mapper.Map<Order>(dto);

        return this.mapper.Map<OrderForResultDto>(updatedOrder);
    }
}
