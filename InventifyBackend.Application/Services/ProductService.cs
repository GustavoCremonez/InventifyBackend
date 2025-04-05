using InventifyBackend.Application.Contracts;
using InventifyBackend.Application.Dtos.Product;

namespace InventifyBackend.Application.Services;

public class ProductService : IProductService
{
    public Task<ProductDto> GetProductByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddProductAsync(ProductCreateResource product)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProductAsync(ProductUpdateResource product)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProductAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(string category)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductDto>> SearchProductsAsync(string searchTerm)
    {
        throw new NotImplementedException();
    }
}