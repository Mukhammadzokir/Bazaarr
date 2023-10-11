using Bazaarr.Domain.Models;
using Bazaarr.Service.DTOs.User;

namespace Bazaarr.Service.DTOs.Order;

public class OrderForResultDto
{
    public long Id { get; set; }
    public User.UserForResultDto User { get; set; }
    public decimal TotalPrice { get; set; }
}
