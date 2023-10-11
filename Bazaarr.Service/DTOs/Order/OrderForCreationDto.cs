using Bazaarr.Domain.Models;

namespace Bazaarr.Service.DTOs.Order;

public class OrderForCreationDto
{
    public long UserId { get; set; }
    public decimal TotalPrice { get; set; }
}
