using InventifyBackend.Domain.Entity;

namespace InventifyBackend.Domain.Contracts
{
    public interface ICategorieRepository
    {
        Task<Categorie?> Get(Guid id, CancellationToken cancellationToken);
    }
}
