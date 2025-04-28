using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using InventifyBackend.Application.Configuration;
using InventifyBackend.Application.Contracts;
using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.Login;
using InventifyBackend.Application.Dtos.User;
using InventifyBackend.Application.Helper;
using InventifyBackend.Domain.Contracts;
using InventifyBackend.Domain.Entity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InventifyBackend.Application.Services;

public class AuthService(
    IUserService userService,
    IOptions<PasswordSettings> passwordSettings,
    IOptions<JwtSettings> jwtSettings,
    IGeneralRepository generalRepository,
    ITokenRepository tokenRepository)
    : IAuthService
{
    private readonly PasswordSettings _passwordSettings = passwordSettings.Value;
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;
    private readonly int _iteration = 3;

    public async Task<ResponseDto<AuthResponseDto>> LoginAsync(LoginResource resource, string ipAddress,
        CancellationToken cancellationToken)
    {
        ResponseDto<UserDto> userResponse = await userService.Get(resource.email, cancellationToken);
        if (userResponse.StatusCode != 200)
        {
            return ResponseDto<AuthResponseDto>.Failure(400, "Invalid user credentials.");
        }

        UserDto userData = userResponse.Data;

        string hashedPassword = PasswordHelper.ComputeHash(resource.password, userData.PasswordSalt,
            _passwordSettings.Pepper, _iteration);

        if (hashedPassword != userData.PasswordHash)
        {
            return ResponseDto<AuthResponseDto>.Failure(400, "Invalid user credentials.");
        }

        string accessToken = GenerateJwtToken(userData.Email);
        RefreshToken refreshToken = GenerateRefreshToken(ipAddress, userData.Id.Value);

        await SaveRefreshToken(refreshToken, cancellationToken);

        var response = new AuthResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken.Token
        };

        return ResponseDto<AuthResponseDto>.Success(response);
    }

    public async Task<ResponseDto<AuthResponseDto>> RefreshTokenAsync(string token, string ipAddress,
        CancellationToken cancellationToken)
    {
        var refreshToken = await GetRefreshToken(token, cancellationToken);

        if (refreshToken is not { IsActive: true })
            return ResponseDto<AuthResponseDto>.Failure(400, "Invalid refresh token");

        var user = await userService.Get(refreshToken.UserId, cancellationToken);
        var newRefreshToken = GenerateRefreshToken(ipAddress, user.Data.Id.Value);
        
        await RevokeRefreshToken(refreshToken, ipAddress, newRefreshToken.Token);
        await SaveRefreshToken(newRefreshToken, cancellationToken);

        var accessToken = GenerateJwtToken(user.Data.Email);

        var response = new AuthResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = newRefreshToken.Token
        };

        return ResponseDto<AuthResponseDto>.Success(response);
    }

    private string GenerateJwtToken(string username)
    {
        Claim[] claims =
        [
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        ];

        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddHours(_jwtSettings.TimeTokenExpiration),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private RefreshToken GenerateRefreshToken(string ipAddress, Guid userId)
    {
        using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
        var randomBytes = new byte[64];
        rngCryptoServiceProvider.GetBytes(randomBytes);
        
        return new RefreshToken
        {
            Token = Convert.ToBase64String(randomBytes),
            Expires = DateTime.UtcNow.AddDays(7),
            Created = DateTime.UtcNow,
            CreatedByIp = ipAddress,
            UserId = userId
        };
    }

    private async Task<RefreshToken> GetRefreshToken(string token, CancellationToken cancellationToken)
    {
        return await tokenRepository.GetByTokenAsync(token, cancellationToken); 
    }

    private async Task SaveRefreshToken(RefreshToken refreshToken, CancellationToken cancellationToken)
    {
        await generalRepository.Add<RefreshToken>(refreshToken, cancellationToken);
        await generalRepository.SaveAsync();
    }

    private async Task RevokeRefreshToken(RefreshToken token, string ipAddress, string replacedByToken = "")
    {
        token.Revoked = DateTime.UtcNow;
        token.RevokedByIp = ipAddress;
        token.ReplacedByToken = replacedByToken;
        await generalRepository.SaveAsync();
    }
}