using InventifyBackend.Domain.Entity;

namespace InventifyBackend.Domain.Contracts;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(Guid id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task UpdateAsync(Product product);
    Task<IEnumerable<Product>> SearchAsync(string searchTerm);
}