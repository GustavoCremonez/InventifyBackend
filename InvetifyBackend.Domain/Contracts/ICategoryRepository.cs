using InventifyBackend.Domain.Entity;

namespace InventifyBackend.Domain.Contracts
{
    public interface ICategoryRepository
    {
        Task<Category?> Get(Guid id, CancellationToken cancellationToken);
    }
}
