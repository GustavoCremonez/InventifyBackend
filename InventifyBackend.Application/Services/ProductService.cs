using AutoMapper;
using InventifyBackend.Application.Contracts;
using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.Product;
using InventifyBackend.Domain.Contracts;
using InventifyBackend.Domain.Entity;

namespace InventifyBackend.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryService _categoryService;
    private readonly IGeneralRepository _generalRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IGeneralRepository generalRepository, IMapper mapper,
        ICategoryService categoryService)
    {
        _productRepository = productRepository;
        _generalRepository = generalRepository;
        _categoryService = categoryService;
        _mapper = mapper;
    }

    public async Task<ResponseDto<ProductDto>> GetProductByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(id, cancellationToken);
        var mappedProduct = _mapper.Map<ProductDto>(product);

        return ResponseDto<ProductDto>.Success(mappedProduct);
    }

    public async Task<ResponseDto<IEnumerable<ProductDto>>> GetAllProductsAsync(CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync(cancellationToken);
        var mappedProducts = _mapper.Map<IEnumerable<ProductDto>>(products);

        return ResponseDto<IEnumerable<ProductDto>>.Success(mappedProducts);
    }

    public async Task<ResponseDto<IEnumerable<ProductDto>>> GetProductsByCategoryAsync(string category,
        CancellationToken cancellationToken)
    {
        var products = await _productRepository.SearchAsync(category, cancellationToken);
        var mappedProducts = _mapper.Map<IEnumerable<ProductDto>>(products);

        return ResponseDto<IEnumerable<ProductDto>>.Success(mappedProducts);
    }

    public async Task<ResponseDto<IEnumerable<ProductDto>>> SearchProductsAsync(string searchTerm,
        CancellationToken cancellationToken)
    {
        var products = await _productRepository.SearchAsync(searchTerm, cancellationToken);
        var mappedProducts = _mapper.Map<IEnumerable<ProductDto>>(products);

        return ResponseDto<IEnumerable<ProductDto>>.Success(mappedProducts);
    }

    public async Task AddProductAsync(ProductCreateResource productResource, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(productResource);

        if (productResource.CategoryIds.Count != 0)
        {
            foreach (var categoryId in productResource.CategoryIds)
            {
                var category = await _categoryService.Get(categoryId, cancellationToken);
                product.AddProductCategory(new ProductCategory
                (
                    product.Id,
                    categoryId
                ));
            }
        }

        await _generalRepository.Add(product, cancellationToken);
        await _generalRepository.SaveAsync();
    }

    public Task UpdateProductAsync(ProductUpdateResource product, CancellationToken cancellationToken)
    {
        var mappedProduct = _mapper.Map<Product>(product);
        _productRepository.UpdateAsync(mappedProduct, cancellationToken);
        return _generalRepository.SaveAsync();
    }

    public async Task DeleteProductAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(id, cancellationToken);
        await _generalRepository.Delete(product);
        await _generalRepository.SaveAsync();
    }
}