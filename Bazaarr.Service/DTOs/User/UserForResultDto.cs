using Bazaarr.Service.DTOs.Cart;

namespace Bazaarr.Service.DTOs.User;

public class UserForResultDto
{
    public long Id { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<CartForResultDto> Carts { get; set; }
}
