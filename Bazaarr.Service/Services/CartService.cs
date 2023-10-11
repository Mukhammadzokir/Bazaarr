using AutoMapper;
using Bazaarr.Data.IRepositories;
using Bazaarr.Data.Repositories;
using Bazaarr.Domain.Models;
using Bazaarr.Service.DTOs.Cart;
using Bazaarr.Service.Exceptions;
using Bazaarr.Service.Interfaces;
using Bazaarr.Service.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Bazaarr.Service.Services;

public class CartService : ICartService
{
    private readonly IMapper mapper = MappingProfile.Initialize();
    private readonly IRepository<Cart> cartRepository = new Repository<Cart>();

    public async Task<CartForResultDto> CreateAsync(CartForCreationDto dto)
    {
        var cart = await this.cartRepository.SelectAll()
            .FirstOrDefaultAsync(c => c.UserId == dto.UserId);
        if (cart is not null)
            throw new CustomException(400, "Cart is already exist");

        var mappedCart = this.mapper.Map<Cart>(dto);

        var insertedCart = await this.cartRepository.InsertAsync(mappedCart);

        return this.mapper.Map<CartForResultDto>(insertedCart);

    }

    public async Task<bool> RemoveAsync(long id)
    {
        var cart = await this.cartRepository.SelectByIdAsync(id);
        if (cart is null)
            throw new CustomException(404, "Cart is not found");

        await this.cartRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<CartForResultDto>> RetrieveAllAsync()
    {
        var carts = await this.cartRepository.SelectAll()
            .Include(c => c.User)
            .ToListAsync();

        var mappedCarts = this.mapper.Map<IEnumerable<CartForResultDto>>(carts);
        return mappedCarts;
    }

    public async Task<CartForResultDto> RetrieveByIdAsync(long id)
    {
        var cart = await this.cartRepository.SelectByIdAsync(id);
        if (cart is null)
            throw new CustomException(404, "Cart is not found");

        var mappedCart = this.mapper.Map<CartForResultDto>(cart);

        return mappedCart;
    }

    public async Task<CartForResultDto> UpdateAsync(CartForUpdateDto dto)
    {
        var cart = await this.cartRepository.SelectByIdAsync(dto.Id);
        if (cart is null)
            throw new CustomException(404, "Cart is not found");

        var mappedCart = this.mapper.Map<Cart>(dto);

        var updatedCart = await this.cartRepository.UpdateAsync(mappedCart);

        return this.mapper.Map<CartForResultDto>(updatedCart);
    }
}
