using InventifyBackend.Domain.Entity;

namespace InventifyBackend.Domain.Contracts
{
    public interface IUserRepository
    {
        Task<User?> Get(Guid id, CancellationToken cancellationToken);

        Task<User?> Get(string email, CancellationToken cancellationToken);
    }
}
