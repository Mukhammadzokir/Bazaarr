using Bazaarr.Service.DTOs.OrderItem;

namespace Bazaarr.Service.Interfaces;

public interface IOrderItemService
{
    public Task<bool> RemoveAsync(long id);
    public Task<OrderItemForResultDto> RetrieveByIdAsync(long id);
    public Task<IEnumerable<OrderItemForResultDto>> RetrieveAllAsync();
    public Task<OrderItemForResultDto> UpdateAsync(OrderItemForUpdateDto dto);
    public Task<OrderItemForResultDto> CreateAsync(OrderItemForCreationDto dto);
}
