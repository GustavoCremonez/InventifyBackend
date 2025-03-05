using InventifyBackend.Domain.Contracts;
using InventifyBackend.Domain.Entity;
using InventifyBackend.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace InventifyBackend.Infra.Repositories
{
    public class CategorieRepository : ICategorieRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategorieRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Categorie?> Get(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                Categorie? categorie = await _applicationDbContext.Categories.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

                return categorie;
            }
            catch
            {
                throw new Exception("An error ocurred when trying to get categorie.");
            }
        }
    }
}
