using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.Categories;

namespace InventifyBackend.Application.Contracts
{
    public interface ICategoryService
    {
        Task<ResponseDto<Guid>> Add(CategoryCreateResource categoryResource, CancellationToken cancellationToken);

        Task<ResponseDto<CategoryDto>> Get(Guid id, CancellationToken cancellationToken);
        
        Task<ResponseDto<IEnumerable<CategoryDto>>> GetAll(CancellationToken cancellationToken);

        Task<ResponseDto<CategoryDto>> Update(CategoryUpdateResource? categoryResource, CancellationToken cancellationToken);

        Task<ResponseDto<Guid>> Delete(Guid id, CancellationToken cancellationToken);
    }
}
