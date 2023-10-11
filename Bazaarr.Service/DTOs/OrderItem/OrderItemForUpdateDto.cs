using Bazaarr.Domain.Models;

namespace Bazaarr.Service.DTOs.OrderItem;

public class OrderItemForUpdateDto
{
    public long Id { get; set; }
    public long ProductId { get; set; }
    public long OrderId { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
