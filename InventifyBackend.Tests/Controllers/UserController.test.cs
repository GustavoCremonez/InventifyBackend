using Bogus;
using InventifyBackend.Api.Controllers;
using InventifyBackend.Application.Contracts;
using InventifyBackend.Application.Dtos.User;
using InventifyBackend.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace InventifyBackend.Tests.Controllers
{
    public class UserControllerTests
    {
        private readonly Faker _faker = new("pt_BR");
        private readonly Mock<IUserService> _mockUserService;
        private readonly UserController _userController;

        public UserControllerTests()
        {
            _mockUserService = new Mock<IUserService>();
            _userController = new UserController(_mockUserService.Object);
        }

        #region Add
        [Fact]
        public async Task Add_ValidUser_ThenShouldReturnOkResult()
        {
            UserCreateResource userCreateResource = new(_faker.Person.FullName, _faker.Internet.Email(), _faker.Internet.Password());

            ResponseDto<Guid> expectedResponse = ResponseDto<Guid>.Success(new Guid());

            _mockUserService
                .Setup(x => x.Add(It.IsAny<UserCreateResource>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            ActionResult result = await _userController.Add(userCreateResource, CancellationToken.None);

            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
            ResponseDto<Guid> responseDto = Assert.IsType<ResponseDto<Guid>>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(expectedResponse, responseDto);
        }

        [Fact]
        public async Task Add_InvalidUser_ThenShouldReturnBadRequestResult()
        {
            UserCreateResource userCreateResource = new(_faker.Person.FullName, _faker.Internet.Email(), _faker.Internet.Password());

            ResponseDto<Guid> expectedResponse = ResponseDto<Guid>.Failure(StatusCodes.Status400BadRequest, "Invalid user data.");

            _mockUserService
                .Setup(x => x.Add(It.IsAny<UserCreateResource>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            ActionResult result = await _userController.Add(userCreateResource, CancellationToken.None);

            BadRequestObjectResult badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            ResponseDto<Guid> responseDto = Assert.IsType<ResponseDto<Guid>>(badRequestResult.Value);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal(expectedResponse, responseDto);
        }

        [Fact]
        public async Task Add_Unexpedted_ThenShouldReturnInternalServerErrorResult()
        {
            UserCreateResource userCreateResource = new(_faker.Person.FullName, _faker.Internet.Email(), _faker.Internet.Password());

            ResponseDto<Guid> expectedResponse = ResponseDto<Guid>.Failure(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");

            _mockUserService
                .Setup(x => x.Add(It.IsAny<UserCreateResource>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            ActionResult result = await _userController.Add(userCreateResource, CancellationToken.None);

            ObjectResult objectResult = Assert.IsType<ObjectResult>(result);
            ResponseDto<Guid> responseDto = Assert.IsType<ResponseDto<Guid>>(objectResult.Value);
            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
            Assert.Equal(expectedResponse, responseDto);
        }
        #endregion Add

        #region Get
        [Fact]
        public async Task Get_ValidEmail_ThenShouldReturnOkResult()
        {
            string userEmail = _faker.Internet.Email();

            ResponseDto<UserDto> expectedResponse = ResponseDto<UserDto>.Success(new UserDto
            {
                Email = userEmail
            });

            _mockUserService
                .Setup(x => x.GetAbstracted(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            ActionResult result = await _userController.Get(userEmail, CancellationToken.None);

            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
            ResponseDto<UserDto> responseDto = Assert.IsType<ResponseDto<UserDto>>(okResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(expectedResponse, responseDto);
        }

        [Fact]
        public async Task Get_InvalidEmail_ThenShouldReturnBadRequestResult()
        {
            string userEmail = _faker.Internet.Email();

            ResponseDto<UserDto> expectedResponse = ResponseDto<UserDto>.Failure(StatusCodes.Status400BadRequest, "Invalid email");

            _mockUserService
                .Setup(x => x.GetAbstracted(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResponse);

            ActionResult result = await _userController.Get(userEmail, CancellationToken.None);

            BadRequestObjectResult badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            ResponseDto<UserDto> responseDto = Assert.IsType<ResponseDto<UserDto>>(badRequestResult.Value);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal(expectedResponse, responseDto);
        }

        [Fact]
        public async Task Get_Unexpedted_ThenShouldReturnInternalServerErrorResult()
        {
            string userEmail = _faker.Internet.Email();

            ResponseDto<UserDto> expectedResponse = ResponseDto<UserDto>.Failure(StatusCodes.Status500InternalServerError, "An unexpected error occurred");

            _mockUserService
                .Setup(x => x.GetAbstracted(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            ActionResult result = await _userController.Get(userEmail, CancellationToken.None);

            ObjectResult objectResult = Assert.IsType<ObjectResult>(result);
            ResponseDto<UserDto> responseDto = Assert.IsType<ResponseDto<UserDto>>(objectResult.Value);
            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
            Assert.Equal(expectedResponse, responseDto);
        }
        #endregion Get

        #region Update
        [Fact]
        public async Task Update_ValidUser_ThenShouldReturnOkResult()
        {
            Guid expectedGuid = new Guid();
            string expectedName = _faker.Person.FullName;
            string expectedEmail = _faker.Internet.Email();

            UserUpdateResource userUpdateResource = new(expectedGuid, _faker.Person.FullName, expectedEmail, _faker.Internet.Password());

            ResponseDto<UserDto> expectedResponse = ResponseDto<UserDto>.Success(new UserDto { Id = expectedGuid, Name = expectedName, Email = expectedEmail });

            _mockUserService
                .Setup(x => x.Update(It.IsAny<UserUpdateResource>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            ActionResult result = await _userController.Update(userUpdateResource, CancellationToken.None);

            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
            ResponseDto<UserDto> responseDto = Assert.IsType<ResponseDto<UserDto>>(okResult.Value);

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(expectedResponse, responseDto);
        }

        [Fact]
        public async Task Update_InvalidUser_ThenShouldReturnBadRequestResult()
        {
            Guid expectedGuid = new Guid();
            string expectedName = _faker.Person.FullName;
            string expectedEmail = _faker.Internet.Email();

            UserUpdateResource userUpdateResource = new(expectedGuid, _faker.Person.FullName, expectedEmail, _faker.Internet.Password());

            ResponseDto<UserDto> expectedResponse = ResponseDto<UserDto>.Failure(StatusCodes.Status400BadRequest, "Invalid credentials.");

            _mockUserService
                .Setup(x => x.Update(It.IsAny<UserUpdateResource>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            ActionResult result = await _userController.Update(userUpdateResource, CancellationToken.None);

            BadRequestObjectResult badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            ResponseDto<UserDto> responseDto = Assert.IsType<ResponseDto<UserDto>>(badRequestResult.Value);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal(expectedResponse, responseDto);
        }

        [Fact]
        public async Task Update_Unexpedted_ThenShouldReturnInternalServerErrorResult()
        {
            Guid expectedGuid = new Guid();
            string expectedName = _faker.Person.FullName;
            string expectedEmail = _faker.Internet.Email();

            UserUpdateResource userUpdateResource = new(expectedGuid, _faker.Person.FullName, expectedEmail, _faker.Internet.Password());

            ResponseDto<UserDto> expectedResponse = ResponseDto<UserDto>.Failure(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");

            _mockUserService
                .Setup(x => x.Update(It.IsAny<UserUpdateResource>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            ActionResult result = await _userController.Update(userUpdateResource, CancellationToken.None);

            ObjectResult objectResult = Assert.IsType<ObjectResult>(result);
            ResponseDto<UserDto> responseDto = Assert.IsType<ResponseDto<UserDto>>(objectResult.Value);
            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
            Assert.Equal(expectedResponse, responseDto);
        }
        #endregion Update

        #region Delete
        [Fact]
        public async Task Delete_ValidEmail_ThenShouldReturnOkResult()
        {
            string deleteEmail = _faker.Internet.Email();

            ResponseDto<Guid> expectedResponse = ResponseDto<Guid>.Success(new Guid());

            _mockUserService
                .Setup(x => x.Delete(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            ActionResult result = await _userController.Delete(deleteEmail, CancellationToken.None);

            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
            ResponseDto<Guid> responseDto = Assert.IsType<ResponseDto<Guid>>(okResult.Value);

            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(expectedResponse, responseDto);
        }

        [Fact]
        public async Task Delete_InvalidEmail_ThenShouldReturnBadRequestResult()
        {
            string deleteEmail = _faker.Internet.Email();

            ResponseDto<Guid> expectedResponse = ResponseDto<Guid>.Failure(StatusCodes.Status400BadRequest, "Invalid email.");

            _mockUserService
                .Setup(x => x.Delete(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            ActionResult result = await _userController.Delete(deleteEmail, CancellationToken.None);

            BadRequestObjectResult badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            ResponseDto<Guid> responseDto = Assert.IsType<ResponseDto<Guid>>(badRequestResult.Value);
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal(expectedResponse, responseDto);
        }

        [Fact]
        public async Task Delete_Unexpedted_ThenShouldReturnInternalServerErrorResult()
        {
            string deleteEmail = _faker.Internet.Email();

            ResponseDto<Guid> expectedResponse = ResponseDto<Guid>.Failure(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");

            _mockUserService
                .Setup(x => x.Delete(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            ActionResult result = await _userController.Delete(deleteEmail, CancellationToken.None);

            ObjectResult objectResult = Assert.IsType<ObjectResult>(result);
            ResponseDto<Guid> responseDto = Assert.IsType<ResponseDto<Guid>>(objectResult.Value);
            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
            Assert.Equal(expectedResponse, responseDto);
        }
        #endregion Delete
    }
}
