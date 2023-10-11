using Bazaarr.Domain.Commons;

namespace Bazaarr.Domain.Models;

public class Cart : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
}
