using InventifyBackend.Domain.Contracts;
using InventifyBackend.Domain.Entity;
using InventifyBackend.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace InventifyBackend.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Category?> Get(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                Category? category = await _applicationDbContext.Categories.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

                return category;
            }
            catch
            {
                throw new Exception("An error ocurred when trying to get category.");
            }
        }
        
        public async Task<IEnumerable<Category>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var categories = await _applicationDbContext.Categories.ToListAsync(cancellationToken);

                return categories;
            }
            catch
            {
                throw new Exception("An error ocurred when trying to get categories.");
            }
        }
    }
}
