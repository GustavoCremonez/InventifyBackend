using InventifyBackend.Application.Dtos.Categories;

namespace InventifyBackend.Application.Dtos.Product;

public record ProductUpdateResource(Guid Id, string Name, decimal Price, decimal Quantity, CategoryDto Categories);