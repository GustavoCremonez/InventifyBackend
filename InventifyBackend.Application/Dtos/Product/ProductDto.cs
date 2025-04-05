using InventifyBackend.Application.Dtos.Categories;
using InventifyBackend.Application.Dtos.User;

namespace InventifyBackend.Application.Dtos.Product;

public record ProductDto
{
    public Guid Id { get; set; }
    
    public UserDto User { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public decimal Quantity { get; set; }

    public CategoryDto Categories { get;  set; }
    
    public DateTime? CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}