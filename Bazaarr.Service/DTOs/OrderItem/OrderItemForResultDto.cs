using Bazaarr.Domain.Models;
using Bazaarr.Service.DTOs.Order;
using Bazaarr.Service.DTOs.Product;

namespace Bazaarr.Service.DTOs.OrderItem;

public class OrderItemForResultDto
{
    public long Id { get; set; }
    public ProductForResultDto Product { get; set; }
    public OrderForResultDto Order { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
