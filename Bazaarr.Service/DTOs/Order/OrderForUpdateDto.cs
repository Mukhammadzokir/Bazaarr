using Bazaarr.Domain.Models;

namespace Bazaarr.Service.DTOs.Order;

public class OrderForUpdateDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public decimal TotalPrice { get; set; }
}
