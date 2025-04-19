namespace InventifyBackend.Application.Dtos.Product;

public record ProductUpdateResource(Guid Id, string Name, decimal Price, decimal Quantity, List<ProductCategoryDto> ProductCategories);