
using Bazaarr.Service.DTOs.Cart;
using Bazaarr.Service.DTOs.Product;

namespace Bazaarr.Service.DTOs.CartItem;

public class CartItemForResultDto
{
    public long Id { get; set; }
    public CartForResultDto Cart { get; set; }
    public ProductForResultDto Product { get; set; }
}
