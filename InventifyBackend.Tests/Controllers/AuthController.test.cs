using Bogus;
using InventifyBackend.Api.Controllers;
using InventifyBackend.Application.Contracts;
using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.Login;
using InventifyBackend.Application.Dtos.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace InventifyBackend.Tests.Controllers
{
    public class AuthControllerTests
    {
        private readonly Faker _faker = new("pt_BR");
        private readonly Mock<IAuthService> _mockAuthService;
        private readonly AuthController _authController;

        public AuthControllerTests()
        {
            _mockAuthService = new Mock<IAuthService>();
            _authController = new AuthController(_mockAuthService.Object);
        }

        [Fact]
        public async Task Login_ValidCredentials_ReturnsOkResult()
        {
            // Arrange
            LoginResource loginResource = new(_faker.Internet.Email(), _faker.Internet.Password());

            ResponseDto<object> expectedResponse = ResponseDto<object>.Success(new UserDto());

            _mockAuthService
                .Setup(x => x.LoginAsync(It.IsAny<LoginResource>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            Microsoft.AspNetCore.Mvc.ActionResult result = await _authController.Login(loginResource, CancellationToken.None);

            // Assert
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
            ResponseDto<object> responseDto = Assert.IsType<ResponseDto<object>>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(expectedResponse, responseDto);
        }

        [Fact]
        public async Task Login_InvalidCredentials_ReturnsBadRequestResult()
        {
            // Arrange
            LoginResource loginResource = new(_faker.Internet.Email(), _faker.Internet.Password());

            ResponseDto<object> expectedResponse = ResponseDto<object>.Failure(StatusCodes.Status400BadRequest, "Invalid credentials");

            _mockAuthService
                .Setup(x => x.LoginAsync(It.IsAny<LoginResource>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            ActionResult result = await _authController.Login(loginResource, CancellationToken.None);

            // Assert
            BadRequestObjectResult badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            ResponseDto<object> responseDto = Assert.IsType<ResponseDto<object>>(badRequestResult.Value);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal(expectedResponse, responseDto);
        }

        [Fact]
        public async Task Login_UnexpectedError_ReturnsInternalServerErrorResult()
        {
            // Arrange
            LoginResource loginResource = new(_faker.Internet.Email(), _faker.Internet.Password());

            ResponseDto<object> expectedResponse = ResponseDto<object>.Failure(StatusCodes.Status500InternalServerError, "An unexpected error occurred");

            _mockAuthService
                .Setup(x => x.LoginAsync(It.IsAny<LoginResource>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            ActionResult result = await _authController.Login(loginResource, CancellationToken.None);

            // Assert
            ObjectResult objectResult = Assert.IsType<ObjectResult>(result);
            ResponseDto<object> responseDto = Assert.IsType<ResponseDto<object>>(objectResult.Value);
            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
            Assert.Equal(expectedResponse, responseDto);
        }

        [Fact]
        public async Task Login_ConcurrentRequests_HandlesAllRequestsCorrectly()
        {
            // Arrange
            int concurrentRequests = 5;
            List<LoginResource> loginResources = Enumerable.Range(0, concurrentRequests)
        .Select(_ => new LoginResource(_faker.Internet.Email(), _faker.Internet.Password()))
        .ToList();

            List<ResponseDto<object>> expectedResponses = loginResources.Select(_ => ResponseDto<object>.Success(new UserDto())).ToList();

            _mockAuthService
                .Setup(x => x.LoginAsync(It.IsAny<LoginResource>(), It.IsAny<CancellationToken>()))
                .Returns<LoginResource, CancellationToken>((_, _) => Task.FromResult(expectedResponses[0]));

            CancellationTokenSource cts = new();

            // Act
            List<Task<ActionResult>> tasks = loginResources.Select(resource =>
        _authController.Login(resource, cts.Token)).ToList();

            ActionResult[] results = await Task.WhenAll(tasks);

            // Assert
            Assert.Equal(concurrentRequests, results.Length);
            foreach (ActionResult? result in results)
            {
                OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
                ResponseDto<object> responseDto = Assert.IsType<ResponseDto<object>>(okResult.Value);
                Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
                Assert.Equal(expectedResponses[0], responseDto);
            }

            _mockAuthService.Verify(x => x.LoginAsync(It.IsAny<LoginResource>(), It.IsAny<CancellationToken>()), Times.Exactly(concurrentRequests));
        }
    }
}
