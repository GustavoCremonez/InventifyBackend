using InventifyBackend.Domain.Contracts;
using InventifyBackend.Domain.Entity;
using InventifyBackend.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace InventifyBackend.Infra.Repositories;

public class TokenRepository(ApplicationDbContext aplicationDbContext) : ITokenRepository
{
    
    public async Task<RefreshToken> GetByTokenAsync(string token, CancellationToken cancellationToken)
    {
        return await aplicationDbContext.RefreshTokens.FirstAsync(x => x.Token == token, cancellationToken);
    }
}