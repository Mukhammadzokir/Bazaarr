using Bazaarr.Domain.Models;
using Bazaarr.Service.DTOs.Product;

namespace Bazaarr.Service.DTOs.Category;

public class CategoryForResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<ProductForResultDto> Products { get; set; }
}
