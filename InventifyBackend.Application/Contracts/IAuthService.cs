using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.Login;

namespace InventifyBackend.Application.Contracts
{
    public interface IAuthService
    {
        Task<ResponseDto<object>> LoginAsync(UserResource resource, CancellationToken cancellationToken);
    }
}
