using Bazaarr.Service.DTOs.Category;

namespace Bazaarr.Service.Interfaces;

public interface ICategoryService
{
    public Task<bool> RemoveAsync(long id);
    public Task<CategoryForResultDto> RetrieveByIdAsync(long id);
    public Task<IEnumerable<CategoryForResultDto>> RetrieveAllAsync();
    public Task<CategoryForResultDto> UpdateAsync(CategoryForUpdateDto dto);
    public Task<CategoryForResultDto> CreateAsync(CategoryForCreationDto dto);
}
