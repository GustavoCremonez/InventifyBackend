using InventifyBackend.Domain.Contracts;
using InventifyBackend.Domain.Entity;
using InventifyBackend.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace InventifyBackend.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<User?> Get(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                User? user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

                return user;
            }
            catch
            {
                throw new Exception("Error while searching for user.");
            }
        }

        public async Task<User?> Get(string email, CancellationToken cancellationToken)
        {
            try
            {
                User? user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

                return user;
            }
            catch
            {
                throw new Exception("Error while searching for user.");
            }
        }
    }
}
