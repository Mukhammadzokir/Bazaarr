using Bazaarr.Service.DTOs.Cart;

namespace Bazaarr.Service.Interfaces;

public interface ICartService
{
    public Task<bool> RemoveAsync(long id);
    public Task<CartForResultDto> RetrieveByIdAsync(long id);
    public Task<IEnumerable<CartForResultDto>> RetrieveAllAsync();
    public Task<CartForResultDto> UpdateAsync(CartForUpdateDto dto);
    public Task<CartForResultDto> CreateAsync(CartForCreationDto dto);
}
