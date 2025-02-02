using InventifyBackend.Domain.Entity;

namespace InventifyBackend.Domain.Contracts
{
    public interface IUserRepository
    {
        Task<User?> Get(Guid id);

        Task<User?> Get(string email);
    }
}
