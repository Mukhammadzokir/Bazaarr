using Bazaarr.Service.DTOs.Category;

namespace Bazaarr.Service.DTOs.Product;

public class ProductForResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public CategoryForResultDto Category { get; set; }
    public long StockQuantity { get; set; }
}
