using InventifyBackend.Application.Contracts;
using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.Login;
using InventifyBackend.Application.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventifyBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Authenticates a user and generates a login token.
        /// </summary>
        /// <param name="loginResource">The login credentials provided by the user.</param>
        /// <returns>
        /// An IActionResult containing the login result data if successful.
        /// The result typically includes an access token and possibly a refresh token.
        /// </returns>
        /// <remarks>
        /// This method captures the client's IP address for security logging purposes.
        /// </remarks>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginResource loginResource)
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
            var result = await _authService.LoginAsync(loginResource, ipAddress, HttpContext.RequestAborted);

            return Ok(result.Data);
        }

        /// <summary>
        /// Refreshes an authentication token using a provided refresh token.
        /// </summary>
        /// <param name="refreshTokenResource">The resource containing the refresh token to be used for generating a new access token.</param>
        /// <returns>
        /// An IActionResult containing the refresh result data if successful.
        /// The result typically includes a new access token and possibly a new refresh token.
        /// </returns>
        /// <remarks>
        /// This method captures the client's IP address for security logging purposes.
        /// </remarks>
        [HttpPost("refresh-token")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenResource refreshTokenResource, CancellationToken cancellationToken)
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
            var result = await _authService.RefreshTokenAsync(refreshTokenResource.RefreshToken, ipAddress, cancellationToken);

            return Ok(result.Data);
        }
    }

    public class RefreshTokenResource
    {
        public string RefreshToken { get; set; }
    }
}