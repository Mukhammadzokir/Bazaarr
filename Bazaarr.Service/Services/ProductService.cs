using AutoMapper;
using Bazaarr.Data.IRepositories;
using Bazaarr.Data.Repositories;
using Bazaarr.Domain.Models;
using Bazaarr.Service.DTOs.Product;
using Bazaarr.Service.Exceptions;
using Bazaarr.Service.Interfaces;
using Bazaarr.Service.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Bazaarr.Service.Services;

public class ProductService : IProductService
{
    private readonly IMapper mapper = MappingProfile.Initialize();
    private readonly IRepository<Product> productRepository = new Repository<Product>();
    public async Task<ProductForResultDto> CreateAsync(ProductForCreationDto dto)
    {
        var product = await this.productRepository.SelectAll().
            FirstOrDefaultAsync(p => p.Name.ToLower() == dto.Name.ToLower());
        if (product is not null)
            throw new CustomException(400, "Product is already exist");

        var mappedProduct = this.mapper.Map<Product>(dto);

        var insertedProduct = await this.productRepository.InsertAsync(mappedProduct);

        var result = this.mapper.Map<ProductForResultDto>(insertedProduct);

        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var product = await this.productRepository.SelectByIdAsync(id);
        if (product is null)
            throw new CustomException(404, "Product is not found");

        await this.productRepository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<ProductForResultDto>> RetrieveAllAsync()
    {
        var products = await this.productRepository.SelectAll()
            .Include(p => p.Category)
            .ToListAsync();

        var mappedProducts = this.mapper.Map<IEnumerable<ProductForResultDto>>(products);

        return mappedProducts;
    }

    public async Task<ProductForResultDto> RetrieveByIdAsync(long id)
    {
        var product = await this.productRepository.SelectByIdAsync(id);
        if (product is null)
            throw new CustomException(404, "Product is not found");

        var mappedProduct = this.mapper.Map<ProductForResultDto>(product);

        return mappedProduct;
    }

    public async Task<ProductForResultDto> UpdateAsync(ProductForUpdateDto dto)
    {
        var product = await this.productRepository.SelectByIdAsync(dto.Id);
        if (product is null)
            throw new CustomException(404, "Product is not found");

        var mappedProduct = this.mapper.Map<Product>(dto);
        mappedProduct.UpdatedAt = DateTime.UtcNow;
        var updatedProduct = await this.productRepository.UpdateAsync(mappedProduct);

        return this.mapper.Map<ProductForResultDto>(updatedProduct);
    }
}
