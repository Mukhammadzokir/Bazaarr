using Bazaarr.Service.DTOs.Order;

namespace Bazaarr.Service.Interfaces;

public interface IOrderService
{
    public Task<bool> RemoveAsync(long id);
    public Task<OrderForResultDto> RetrieveByIdAsync(long id);
    public Task<IEnumerable<OrderForResultDto>> RetrieveAllAsync();
    public Task<OrderForResultDto> UpdateAsync(OrderForUpdateDto dto);
    public Task<OrderForResultDto> CreateAsync(OrderForCreationDto dto);
}
