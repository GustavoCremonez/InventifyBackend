using InventifyBackend.Domain.Contracts;
using InventifyBackend.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using InventifyBackend.Infra.Context;

namespace InventifyBackend.Infra.Repositories;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Invalid ID", nameof(id));

        return await _context.Products.FindAsync(new object?[] { id }, cancellationToken: cancellationToken) ??
               throw new InvalidOperationException();
    }

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Products.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(product);

        _context.Products.Update(product);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Product>> SearchAsync(string searchTerm, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return [];

        return await _context.Products
            .AsNoTracking()
            .Where(p => p.Name.Contains(searchTerm))
            .ToListAsync(cancellationToken);
    }
}