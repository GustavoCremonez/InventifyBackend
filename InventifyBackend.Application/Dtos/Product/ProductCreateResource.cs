using InventifyBackend.Application.Dtos.Categories;

namespace InventifyBackend.Application.Dtos.Product;

public record ProductCreateResource(string Name, decimal Price, decimal Quantity, CategoryDto Categories);    