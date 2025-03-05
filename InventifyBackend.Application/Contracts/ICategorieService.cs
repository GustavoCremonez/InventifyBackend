using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.Categories;

namespace InventifyBackend.Application.Contracts
{
    public interface ICategorieService
    {
        Task<ResponseDto<Guid>> Add(CategorieCreateResource categorieResource, CancellationToken cancellationToken);

        Task<ResponseDto<CategorieDto>> Get(Guid id, CancellationToken cancellationToken);

        Task<ResponseDto<CategorieDto>> Update(CategorieUpdateResource categorieResource, CancellationToken cancellationToken);

        Task<ResponseDto<Guid>> Delete(Guid id, CancellationToken cancellationToken);
    }
}
