using FluentAssertions;
using InventifyBackend.Application.Configuration;
using InventifyBackend.Application.Contracts;
using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.Login;
using InventifyBackend.Application.Dtos.User;
using InventifyBackend.Application.Services;
using Microsoft.Extensions.Options;
using Moq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace InventifyBackend.Tests.Services
{
    public class AuthServiceTests
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<IOptions<PasswordSettings>> _mockPasswordSettings;
        private readonly Mock<IOptions<JwtSettings>> _mockJwtSettings;
        private readonly AuthService _authService;

        public AuthServiceTests()
        {
            _mockUserService = new Mock<IUserService>();
            _mockPasswordSettings = new Mock<IOptions<PasswordSettings>>();
            _mockJwtSettings = new Mock<IOptions<JwtSettings>>();

            _mockJwtSettings.Setup(x => x.Value).Returns(new JwtSettings
            {
                SecretKey = "your-secret-key-here-make-it-at-least-32-characters-long",
                Issuer = "your-issuer",
                Audience = "your-audience",
                TimeTokenExpiration = 1
            });

            _mockPasswordSettings.Setup(x => x.Value).Returns(new PasswordSettings { Pepper = "default-pepper" });

            _authService = new AuthService(_mockUserService.Object, _mockPasswordSettings.Object, _mockJwtSettings.Object);
        }

        [Fact]
        public void GenerateJwtToken_ShouldIncludeCorrectSubClaim()
        {
            // Arrange
            string expectedUsername = "testuser@example.com";

            // Act
            string token = _authService.GenerateJwtToken(expectedUsername);

            // Assert
            JwtSecurityTokenHandler tokenHandler = new();
            JwtSecurityToken jwtToken = tokenHandler.ReadJwtToken(token);

            Claim? subClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub);
            subClaim.Should().NotBeNull();
            subClaim!.Value.Should().Be(expectedUsername);
        }

        [Fact]
        public void GenerateJwtToken_ShouldIncludeValidJtiClaim()
        {
            // Arrange
            string username = "testuser@example.com";

            // Act
            string token = _authService.GenerateJwtToken(username);

            // Assert
            JwtSecurityTokenHandler tokenHandler = new();
            JwtSecurityToken jwtToken = tokenHandler.ReadJwtToken(token);

            Claim? jtiClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti);
            jtiClaim.Should().NotBeNull();
            Guid.TryParse(jtiClaim!.Value, out Guid jtiGuid).Should().BeTrue();
            jtiGuid.Should().NotBeEmpty();
        }

        [Fact]
        public void GenerateJwtToken_ShouldUseCorrectIssuerFromJwtSettings()
        {
            // Arrange
            string expectedIssuer = "custom-issuer";
            _mockJwtSettings.Setup(x => x.Value).Returns(new JwtSettings
            {
                SecretKey = "your-secret-key-here-make-it-at-least-32-characters-long",
                Issuer = expectedIssuer,
                Audience = "your-audience",
                TimeTokenExpiration = 1
            });
            AuthService authService = new(_mockUserService.Object, _mockPasswordSettings.Object, _mockJwtSettings.Object);

            // Act
            string token = authService.GenerateJwtToken("testuser@example.com");

            // Assert
            JwtSecurityTokenHandler tokenHandler = new();
            JwtSecurityToken jwtToken = tokenHandler.ReadJwtToken(token);

            jwtToken.Issuer.Should().Be(expectedIssuer);
        }

        [Fact]
        public void GenerateJwtToken_ShouldUseCorrectAudienceFromJwtSettings()
        {
            // Arrange
            string username = "testuser@example.com";
            string expectedAudience = "your-audience";

            // Act
            string token = _authService.GenerateJwtToken(username);

            // Assert
            JwtSecurityTokenHandler tokenHandler = new();
            JwtSecurityToken jwtToken = tokenHandler.ReadJwtToken(token);

            jwtToken.Audiences.Should()
                .Contain(expectedAudience);
        }

        [Fact]
        public void GenerateJwtToken_ShouldSetCorrectExpirationTime()
        {
            // Arrange
            string username = "testuser@example.com";
            DateTime beforeTokenGeneration = DateTime.UtcNow;

            // Act
            string token = _authService.GenerateJwtToken(username);

            // Assert
            JwtSecurityTokenHandler tokenHandler = new();
            JwtSecurityToken jwtToken = tokenHandler.ReadJwtToken(token);

            jwtToken.ValidTo.Should().BeAfter(beforeTokenGeneration);

            TimeSpan expectedDuration = TimeSpan.FromHours(_mockJwtSettings.Object.Value.TimeTokenExpiration);
            TimeSpan actualDuration = jwtToken.ValidTo - beforeTokenGeneration;

            actualDuration.Should().BeCloseTo(expectedDuration, TimeSpan.FromMinutes(1));
        }

        [Fact]
        public async Task LoginAsync_ShouldReturnFailureResponse_WhenUserIsNotFound()
        {
            // Arrange
            LoginResource loginResource = new("nonexistent@example.com", "password123");
            _mockUserService.Setup(x => x.Get(loginResource.email, It.IsAny<CancellationToken>()))
                .ReturnsAsync(ResponseDto<UserDto>.Failure(404, "User not found"));

            // Act
            ResponseDto<object> result = await _authService.LoginAsync(loginResource, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(400);
            result.Message.Should().Be("Error proccessing user info.");
            result.Data.Should().BeNull();
        }

        [Fact]
        public async Task LoginAsync_ShouldReturnFailureResponse_WhenUserServiceReturnsNon200StatusCode()
        {
            // Arrange
            LoginResource loginResource = new("test@example.com", "password123");
            _mockUserService.Setup(x => x.Get(loginResource.email, It.IsAny<CancellationToken>()))
                .ReturnsAsync(ResponseDto<UserDto>.Failure(404, "User not found"));

            // Act
            ResponseDto<object> result = await _authService.LoginAsync(loginResource, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(400);
            result.Message.Should().Be("Error proccessing user info.");
            result.Data.Should().BeNull();
        }

        [Fact]
        public async Task LoginAsync_ShouldReturnFailureResponse_WhenPasswordHashesDontMatch()
        {
            // Arrange
            LoginResource loginResource = new("test@example.com", "incorrectPassword");
            UserDto userDto = new() { Email = "test@example.com", PasswordHash = "correctHash", PasswordSalt = "salt" };

            // Sobrescreva a configuração padrão se necessário
            PasswordSettings passwordSettings = new() { Pepper = "test-pepper" };
            _mockPasswordSettings.Setup(x => x.Value).Returns(passwordSettings);

            _mockUserService.Setup(x => x.Get(loginResource.email, It.IsAny<CancellationToken>()))
                .ReturnsAsync(ResponseDto<UserDto>.Success(userDto));

            // Act
            ResponseDto<object> result = await _authService.LoginAsync(loginResource, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(400);
            result.Message.Should().Be("Error proccessing user info.");
            result.Data.Should().BeNull();
            _mockPasswordSettings.Verify(x => x.Value, Times.AtLeastOnce());
        }

        [Fact]
        public async Task LoginAsync_ShouldReturnFailureResponse_WhenExceptionOccurs()
        {
            // Arrange
            LoginResource loginResource = new("test@example.com", "password123");
            _mockUserService.Setup(x => x.Get(loginResource.email, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Simulated exception"));

            // Act
            ResponseDto<object> result = await _authService.LoginAsync(loginResource, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(500);
            result.Message.Should().Be("Error when authenticating user.");
            result.Data.Should().BeNull();
        }
    }
}
