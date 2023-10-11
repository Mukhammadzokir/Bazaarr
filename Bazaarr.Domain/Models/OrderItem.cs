using Bazaarr.Domain.Commons;

namespace Bazaarr.Domain.Models;

public class OrderItem : Auditable
{
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public long OrderId { get; set; }
    public Order Order { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}

