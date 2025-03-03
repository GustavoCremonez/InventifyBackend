using InventifyBackend.Application.Dtos;

namespace InventifyBackend.Application.Contracts
{
    public interface IAuthService
    {
        Task<ResponseDto<object>> LoginAsync(UserResource resource, CancellationToken cancellationToken);
    }
}
