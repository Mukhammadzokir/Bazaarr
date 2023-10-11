using Bazaarr.Domain.Commons;

namespace Bazaarr.Domain.Models;

public class Category : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Product> Products { get; set; }
}

