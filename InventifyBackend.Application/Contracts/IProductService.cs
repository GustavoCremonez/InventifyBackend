using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.Product;

namespace InventifyBackend.Application.Contracts;

public interface IProductService
{
    Task<ResponseDto<ProductDto>> GetProductByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<ResponseDto<IEnumerable<ProductDto>>> GetAllProductsAsync(CancellationToken cancellationToken);
    Task AddProductAsync(ProductCreateResource product, CancellationToken cancellationToken);
    Task UpdateProductAsync(ProductUpdateResource product, CancellationToken cancellationToken);
    Task DeleteProductAsync(Guid id, CancellationToken cancellationToken);
    Task<ResponseDto<IEnumerable<ProductDto>>> GetProductsByCategoryAsync(string category, CancellationToken cancellationToken);
    Task<ResponseDto<IEnumerable<ProductDto>>> SearchProductsAsync(string searchTerm, CancellationToken cancellationToken);
}