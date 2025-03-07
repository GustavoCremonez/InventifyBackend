using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.Login;

namespace InventifyBackend.Application.Contracts
{
    public interface IAuthService
    {
        Task<ResponseDto<object>> LoginAsync(LoginResource resource, CancellationToken cancellationToken);
    }
}
