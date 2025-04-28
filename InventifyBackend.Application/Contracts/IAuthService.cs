using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.Login;
using InventifyBackend.Domain.Entity;

namespace InventifyBackend.Application.Contracts
{
    public interface IAuthService
    {
        Task<ResponseDto<AuthResponseDto>> LoginAsync(LoginResource resource, string ipAddress, CancellationToken cancellationToken);
        Task<ResponseDto<AuthResponseDto>> RefreshTokenAsync(string token, string ipAddress, CancellationToken cancellationToken);
    }
}
