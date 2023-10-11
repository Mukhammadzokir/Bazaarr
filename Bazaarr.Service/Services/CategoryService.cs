using AutoMapper;
using Bazaarr.Data.IRepositories;
using Bazaarr.Data.Repositories;
using Bazaarr.Domain.Models;
using Bazaarr.Service.DTOs.Category;
using Bazaarr.Service.Exceptions;
using Bazaarr.Service.Interfaces;
using Bazaarr.Service.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Bazaarr.Service.Services;

public class CategoryService : ICategoryService
{
    private readonly IMapper mapper = MappingProfile.Initialize();
    private readonly IRepository<Category> categoryRepository = new Repository<Category>();
    public async Task<CategoryForResultDto> CreateAsync(CategoryForCreationDto dto)
    {
        var category = await this.categoryRepository.SelectAll().
            FirstOrDefaultAsync(c => c.Name.ToLower() == dto.Name.ToLower());

        if (category is not null)
            throw new CustomException(400, "Category is already exist");

        var mappedCategory = this.mapper.Map<Category>(category);

        var insertedCategory = await this.categoryRepository.InsertAsync(mappedCategory);

        var result = this.mapper.Map<CategoryForResultDto>(insertedCategory);

        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var category = await this.categoryRepository.SelectByIdAsync(id);
        if (category is null)
            throw new CustomException(404, "Category is not found");

        await this.categoryRepository.DeleteAsync(id);
        
        return true;
    }

    public async Task<IEnumerable<CategoryForResultDto>> RetrieveAllAsync()
    {
        var category = await this.categoryRepository.SelectAll()
            .Include(c => c.Products)
            .ToListAsync();

        var mappedCategories = this.mapper.Map<IEnumerable<CategoryForResultDto>>(category);

        return mappedCategories;
    }

    public async Task<CategoryForResultDto> RetrieveByIdAsync(long id)
    {
        var category = await this.categoryRepository.SelectByIdAsync(id);
        if (category is null)
            throw new CustomException(404, "Category is not found");

        var mappedCategory = this.mapper.Map<CategoryForResultDto>(category);

        return mappedCategory;

    }

    public async Task<CategoryForResultDto> UpdateAsync(CategoryForUpdateDto dto)
    {
        var category = await this.categoryRepository.SelectByIdAsync(dto.Id);
        if (category is null)
            throw new CustomException(404, "Category is not found");

        var mappedCategory = this.mapper.Map<Category>(dto);
        mappedCategory.UpdatedAt = DateTime.UtcNow;
        var updatedCategory = await this.categoryRepository.UpdateAsync(mappedCategory);

        return this.mapper.Map<CategoryForResultDto>(updatedCategory);
    }
}
