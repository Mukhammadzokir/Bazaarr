using Bazaarr.Domain.Models;

namespace Bazaarr.Service.DTOs.Category;

public class CategoryForUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
