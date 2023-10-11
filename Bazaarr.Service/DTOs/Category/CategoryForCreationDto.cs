using Bazaarr.Domain.Models;

namespace Bazaarr.Service.DTOs.Category;

public class CategoryForCreationDto
{
    public string Name { get; set; }
    public string Description { get; set; }
}
