using InventifyBackend.Domain.Entity;

namespace InventifyBackend.Domain.Contracts;

public interface ITokenRepository
{
    Task<RefreshToken> GetByTokenAsync(string token, CancellationToken cancellationToken);
}