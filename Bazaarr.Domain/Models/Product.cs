using Bazaarr.Domain.Commons;

namespace Bazaarr.Domain.Models;

public class Product : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; }
    public long StockQuantity { get; set; }
}
