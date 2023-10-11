using Bazaarr.Domain.Commons;

namespace Bazaarr.Domain.Models;

public class Order : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public decimal TotalPrice { get; set; }

}
