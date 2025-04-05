using InventifyBackend.Application.Dtos.Product;

namespace InventifyBackend.Application.Contracts;

public interface IProductService
{
    Task<ProductDto> GetProductByIdAsync(Guid id);
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task AddProductAsync(ProductCreateResource product);
    Task UpdateProductAsync(ProductUpdateResource product);
    Task DeleteProductAsync(Guid id);
    Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(string category);
    Task<IEnumerable<ProductDto>> SearchProductsAsync(string searchTerm);
}