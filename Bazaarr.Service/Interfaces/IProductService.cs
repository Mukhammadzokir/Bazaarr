using Bazaarr.Service.DTOs.Product;
using Bazaarr.Service.DTOs.User;

namespace Bazaarr.Service.Interfaces;

public interface IProductService
{
    public Task<bool> RemoveAsync(long id);
    public Task<ProductForResultDto> RetrieveByIdAsync(long id);
    public Task<IEnumerable<ProductForResultDto>> RetrieveAllAsync();
    public Task<ProductForResultDto> UpdateAsync(ProductForUpdateDto dto);
    public Task<ProductForResultDto> CreateAsync(ProductForCreationDto dto);
}
