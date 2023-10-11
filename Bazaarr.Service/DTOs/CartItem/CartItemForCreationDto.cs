using Bazaarr.Domain.Models;

namespace Bazaarr.Service.DTOs.CartItem;

public class CartItemForCreationDto
{
    public long CartId { get; set; }
    public long ProductId { get; set; }
}
