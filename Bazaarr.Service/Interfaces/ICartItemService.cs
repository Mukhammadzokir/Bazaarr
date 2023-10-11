using Bazaarr.Service.DTOs.CartItem;

namespace Bazaarr.Service.Interfaces;

public interface ICartItemService
{
    public Task<bool> RemoveAsync(long id);
    public Task<CartItemForResultDto> RetrieveByIdAsync(long id);
    public Task<IEnumerable<CartItemForResultDto>> RetrieveAllAsync();
    public Task<CartItemForResultDto> UpdateAsync(CartItemForUpdateDto dto);
    public Task<CartItemForResultDto> CreateAsync(CartItemForCreationDto dto);
}
