using InventifyBackend.Domain.Contracts;
using InventifyBackend.Infra.Context;

namespace InventifyBackend.Infra.Repositories
{
    public class GeneralRepository : IGeneralRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GeneralRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<T> GetById<T>(string id, CancellationToken cancellationToken) where T : class
        {
            var data = await _applicationDbContext.Set<T>().FindAsync(id, cancellationToken);
            return data;
        }

        public async Task Add<T>(T entity, CancellationToken cancellationToken) where T : class
        {
            await _applicationDbContext.AddAsync(entity, cancellationToken);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete<T>(T entity) where T : class
        {
            _applicationDbContext.Remove(entity);

            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
