namespace InventifyBackend.Application.Dtos.Product;

public record ProductCreateResource(Guid UserId, string Name, decimal Price, decimal Quantity, List<Guid> CategoryIds);    