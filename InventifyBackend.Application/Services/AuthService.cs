using InventifyBackend.Application.Configuration;
using InventifyBackend.Application.Contracts;
using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Helper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventifyBackend.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly PasswordSettings _passwordSettings;
        private readonly JwtSettings _jwtSettings;
        private readonly int _iteration = 3;

        public AuthService(IUserService userService, IOptions<PasswordSettings> passwordSettings, IOptions<JwtSettings> jwtSettings)
        {
            _userService = userService;
            _passwordSettings = passwordSettings.Value;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<ResponseDto<object>> LoginAsync(UserResource resource, CancellationToken cancellationToken)
        {
            try
            {
                ResponseDto<UserDto> user = await _userService.Get(resource.email, cancellationToken);
                if (user.StatusCode != 200)
                {
                    return ResponseDto<object>.Failure(400, "Error proccessing user info.");
                }

                UserDto userData = user.Data;

                string hashedPassword = PasswordHelper.ComputeHash(resource.password, userData.PasswordSalt, _passwordSettings.Pepper, _iteration);

                if (hashedPassword == userData.PasswordHash)
                {
                    string token = GenerateJwtToken(userData.Email);
                    return ResponseDto<object>.Success(new { token });
                }
                else
                {
                    return ResponseDto<object>.Failure(400, "Error proccessing user info.");
                }
            }
            catch
            {
                return ResponseDto<object>.Failure(500, "Error when authenticating user.");
            }
        }

        private string GenerateJwtToken(string username)
        {
            Claim[] claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(_jwtSettings.TimeTokenExpiration),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
