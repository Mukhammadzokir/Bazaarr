using Bazaarr.Domain.Models;

namespace Bazaarr.Service.DTOs.CartItem;

public class CartItemForUpdateDto
{
    public long Id { get; set; }
    public long CartId { get; set; }
    public long ProductId { get; set; }
}
