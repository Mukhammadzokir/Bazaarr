using Bazaarr.Domain.Models;

namespace Bazaarr.Service.DTOs.Cart;

public class CartForUpdateDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
}
