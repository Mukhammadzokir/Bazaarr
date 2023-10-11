using Microsoft.Identity.Client;

namespace Bazaarr.Service.DTOs.Product;

public class ProductForUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public long CategoryId { get; set; }
    public long StockQuantity { get; set; }
}
