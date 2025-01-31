using InventifyBackend.Domain.Entity;

namespace InventifyBackend.Domain.Contracts
{
    public interface IUserRepository
    {
        Task<User?> Get(string email);
    }
}
