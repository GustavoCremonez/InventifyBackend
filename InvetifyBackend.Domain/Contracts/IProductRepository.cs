using InventifyBackend.Domain.Entity;

namespace InventifyBackend.Domain.Contracts;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken);
    Task UpdateAsync(Product product, CancellationToken cancellationToken);
    Task<IEnumerable<Product>> SearchAsync(string searchTerm, CancellationToken cancellationToken);
}