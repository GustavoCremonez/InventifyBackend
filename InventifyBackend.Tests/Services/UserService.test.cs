using AutoMapper;
using Bogus;
using FluentAssertions;
using InventifyBackend.Application.Configuration;
using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.User;
using InventifyBackend.Application.Helper;
using InventifyBackend.Application.Maps;
using InventifyBackend.Application.Services;
using InventifyBackend.Domain.Contracts;
using InventifyBackend.Domain.Entity;
using InventifyBackend.Domain.Validation;
using Microsoft.Extensions.Options;
using Moq;

namespace InventifyBackend.Tests.Services
{
    public class UserServiceTests
    {
        private readonly Faker _faker = new("pt_BR");
        private readonly Mock<IGeneralRepository> _mockGeneralRepository;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly IMapper _mapper;
        private readonly Mock<IOptions<PasswordSettings>> _mockPasswordSettings;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _mockGeneralRepository = new Mock<IGeneralRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
            _mockPasswordSettings = new Mock<IOptions<PasswordSettings>>();

            _mockPasswordSettings.Setup(x => x.Value).Returns(new PasswordSettings { Pepper = "default-pepper" });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapConfiguration());
            });
            IMapper mapper = mappingConfig.CreateMapper();

            _mapper = mapper;

            _userService = new UserService(_mockGeneralRepository.Object, _mockUserRepository.Object, _mapper, _mockPasswordSettings.Object);
        }

        #region Add
        [Fact]
        public async Task Add_WithValidData_ShouldNotThrowException()
        {
            Guid expectedId = Guid.NewGuid();
            string name = _faker.Person.FullName;
            string email = _faker.Internet.Email(name);

            string password = _faker.Internet.Password();

            UserCreateResource userResource = new UserCreateResource(name, email, password);

            Func<Task> add = async () => await _userService.Add(userResource, CancellationToken.None);

            await add.Should().NotThrowAsync<DomainExceptionValidation>();
        }

        [Fact]
        public async Task Add_GivenEmptyName_ThenShouldThrowException()
        {
            string name = "";
            string email = _faker.Internet.Email(name);

            string password = _faker.Internet.Password();

            UserCreateResource userResource = new UserCreateResource(name, email, password);
            ResponseDto<Guid> expectedResponse = ResponseDto<Guid>.Failure(500, "Error when registering user: The name must not be empty.");

            ResponseDto<Guid> response = await _userService.Add(userResource, CancellationToken.None);

            response.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task Add_GivenEmptyEmail_ThenShouldThrowException()
        {
            string name = _faker.Person.FirstName;
            string email = "";

            string password = _faker.Internet.Password();

            UserCreateResource userResource = new UserCreateResource(name, email, password);
            ResponseDto<Guid> expectedResponse = ResponseDto<Guid>.Failure(500, "Error when registering user: The email must not be empty.");

            ResponseDto<Guid> response = await _userService.Add(userResource, CancellationToken.None);

            response.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task Add_EmailInvalidFormat_ThenShouldThrowException()
        {
            string name = _faker.Person.FirstName;
            string email = "123";

            string password = _faker.Internet.Password();

            UserCreateResource userResource = new UserCreateResource(name, email, password);
            ResponseDto<Guid> expectedResponse = ResponseDto<Guid>.Failure(500, "Error when registering user: The email must be in a valid format.");

            ResponseDto<Guid> response = await _userService.Add(userResource, CancellationToken.None);

            response.Should().BeEquivalentTo(expectedResponse);
        }
        #endregion Add

        #region Get
        [Fact]
        public async Task Get_WithValidEmail_ShouldReturnCorrectlyUser()
        {
            Guid expectedId = Guid.NewGuid();
            string name = _faker.Person.FullName;
            string email = _faker.Internet.Email(name);

            string password = _faker.Internet.Password();

            string pepper = "45a31c6709be8c4fc946d3725c4be48a04053ca7c8ad7909985b2927e92ace4c";
            int iteration = 3;
            string passwordSalt = PasswordHelper.GenerateSalt();
            string passwordHash = PasswordHelper.ComputeHash(password, passwordSalt, pepper, iteration);
            DateTime expectedCreateAt = DateTime.Now;
            DateTime expectedUpdateAt = DateTime.Now;

            User expectedUser = new User(expectedId, name, email, passwordSalt, passwordHash, expectedCreateAt, expectedUpdateAt);

            _mockUserRepository
                .Setup(x => x.Get(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedUser);

            ResponseDto<UserDto> responseUserDto = await _userService.Get(email, CancellationToken.None);

            responseUserDto.Data.Id.Should().Be(expectedUser.Id);
            responseUserDto.Data.Name.Should().Be(expectedUser.Name);
            responseUserDto.Data.Email.Should().Be(expectedUser.Email);
            responseUserDto.Data.PasswordSalt.Should().Be(expectedUser.PasswordSalt);
            responseUserDto.Data.PasswordHash.Should().Be(expectedUser.PasswordHash);
            responseUserDto.Data.CreatedAt.Should().Be(expectedUser.CreatedAt);
            responseUserDto.Data.UpdatedAt.Should().Be(expectedUser.UpdatedAt);
        }

        [Fact]
        public async Task Get_WithInvalidEmail_ShouldReturnNoUser()
        {
            string name = _faker.Person.FullName;
            string email = _faker.Internet.Email(name);

            ResponseDto<UserDto> expectedResponse = ResponseDto<UserDto>.Failure(400, "There is no user with this email.");

            _mockUserRepository
                .Setup(x => x.Get(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(null as User);

            ResponseDto<UserDto> responseUserDto = await _userService.Get(email, CancellationToken.None);

            responseUserDto.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task Get_UnexpectedError_ShouldReturnError()
        {
            string name = _faker.Person.FullName;
            string email = _faker.Internet.Email(name);

            ResponseDto<UserDto> expectedResponse = ResponseDto<UserDto>.Failure(500, "Error when searching for user.");

            _mockUserRepository
                .Setup(x => x.Get(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception());

            ResponseDto<UserDto> responseUserDto = await _userService.Get(email, CancellationToken.None);

            responseUserDto.Should().BeEquivalentTo(expectedResponse);
        }
        #endregion Get

        #region GetAbstracted
        [Fact]
        public async Task GetAbstracted_WithValidEmail_ShouldReturnCorrectlyUser()
        {
            Guid expectedId = Guid.NewGuid();
            string name = _faker.Person.FullName;
            string email = _faker.Internet.Email(name);

            string password = _faker.Internet.Password();

            string pepper = "45a31c6709be8c4fc946d3725c4be48a04053ca7c8ad7909985b2927e92ace4c";
            int iteration = 3;
            string passwordSalt = PasswordHelper.GenerateSalt();
            string passwordHash = PasswordHelper.ComputeHash(password, passwordSalt, pepper, iteration);
            DateTime expectedCreateAt = DateTime.Now;
            DateTime expectedUpdateAt = DateTime.Now;

            User expectedUser = new User(expectedId, name, email, passwordSalt, passwordHash, expectedCreateAt, expectedUpdateAt);

            _mockUserRepository
                .Setup(x => x.Get(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedUser);

            ResponseDto<UserDto> responseUserDto = await _userService.GetAbstracted(email, CancellationToken.None);

            responseUserDto.Data.Id.Should().Be(expectedUser.Id);
            responseUserDto.Data.Name.Should().Be(expectedUser.Name);
            responseUserDto.Data.Email.Should().Be(expectedUser.Email);
            responseUserDto.Data.PasswordSalt.Should().Be(string.Empty);
            responseUserDto.Data.PasswordHash.Should().Be(string.Empty);
            responseUserDto.Data.CreatedAt.Should().Be(expectedUser.CreatedAt);
            responseUserDto.Data.UpdatedAt.Should().Be(expectedUser.UpdatedAt);
        }

        [Fact]
        public async Task GetAbstracted_WithInvalidEmail_ShouldReturnNoUser()
        {
            string name = _faker.Person.FullName;
            string email = _faker.Internet.Email(name);

            ResponseDto<UserDto> expectedResponse = ResponseDto<UserDto>.Failure(400, "There is no user with this email.");

            _mockUserRepository
                .Setup(x => x.Get(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(null as User);

            ResponseDto<UserDto> responseUserDto = await _userService.GetAbstracted(email, CancellationToken.None);

            responseUserDto.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task GetAbstracted_UnexpectedError_ShouldReturnError()
        {
            string name = _faker.Person.FullName;
            string email = _faker.Internet.Email(name);

            ResponseDto<UserDto> expectedResponse = ResponseDto<UserDto>.Failure(500, "Error when searching for user.");

            _mockUserRepository
                .Setup(x => x.Get(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception());

            ResponseDto<UserDto> responseUserDto = await _userService.GetAbstracted(email, CancellationToken.None);

            responseUserDto.Should().BeEquivalentTo(expectedResponse);
        }
        #endregion GetAbstracted

        #region Update
        [Fact]
        public async Task Update_WithValidData_ShouldReturnCorrectlyUser()
        {
            Guid expectedId = Guid.NewGuid();
            string name = _faker.Person.FullName;
            string email = _faker.Internet.Email(name);
            string password = _faker.Internet.Password();

            string pepper = "45a31c6709be8c4fc946d3725c4be48a04053ca7c8ad7909985b2927e92ace4c";
            int iteration = 3;
            string passwordSalt = PasswordHelper.GenerateSalt();
            string passwordHash = PasswordHelper.ComputeHash(password, passwordSalt, pepper, iteration);
            DateTime expectedCreateAt = DateTime.Now;
            DateTime expectedUpdateAt = DateTime.Now;

            User expectedUser = new User(expectedId, name, email, passwordSalt, passwordHash, expectedCreateAt, expectedUpdateAt);

            string updateName = _faker.Person.FirstName;
            string updateEmail = _faker.Internet.Email(updateName);

            string updatePassword = _faker.Internet.Password();

            UserUpdateResource userUpdateResource = new UserUpdateResource(expectedId, updateName, updateEmail, updatePassword);

            _mockUserRepository
                .Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedUser);

            ResponseDto<UserDto> responseUserDto = await _userService.Update(userUpdateResource, CancellationToken.None);

            responseUserDto.Data.Id.Should().Be(expectedUser.Id);
            responseUserDto.Data.Name.Should().Be(userUpdateResource.name);
            responseUserDto.Data.Email.Should().Be(userUpdateResource.email);
            responseUserDto.Data.PasswordSalt.Should().Be(expectedUser.PasswordSalt);
            responseUserDto.Data.PasswordHash.Should().Be(expectedUser.PasswordHash);
            responseUserDto.Data.CreatedAt.Should().Be(expectedUser.CreatedAt);
            responseUserDto.Data.UpdatedAt.Should().Be(expectedUser.UpdatedAt);
        }

        [Fact]
        public async Task Update_WithEmptyData_ShouldReturnNoUser()
        {
            ResponseDto<UserDto> expectedResponse = ResponseDto<UserDto>.Failure(400, "The user information must contain a value.");

            ResponseDto<UserDto> responseUserDto = await _userService.Update(null as UserUpdateResource, CancellationToken.None);

            responseUserDto.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task Update_WithInvalidId_ShouldReturnNoUser()
        {
            Guid expectedId = Guid.NewGuid();
            string name = _faker.Person.FullName;
            string email = _faker.Internet.Email(name);
            string password = _faker.Internet.Password();

            UserUpdateResource userUpdateResource = new UserUpdateResource(expectedId, name, email, password);

            ResponseDto<UserDto> expectedResponse = ResponseDto<UserDto>.Failure(400, "There is no user with this email.");

            _mockUserRepository
                .Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(null as User);

            ResponseDto<UserDto> responseUserDto = await _userService.Update(userUpdateResource, CancellationToken.None);

            responseUserDto.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task Update_WithEmptyName_ShouldReturnNoUser()
        {
            Guid expectedId = Guid.NewGuid();
            string name = _faker.Person.FullName;
            string updateName = "";
            string email = _faker.Internet.Email();
            string password = _faker.Internet.Password();

            string pepper = "45a31c6709be8c4fc946d3725c4be48a04053ca7c8ad7909985b2927e92ace4c";
            int iteration = 3;
            string passwordSalt = PasswordHelper.GenerateSalt();
            string passwordHash = PasswordHelper.ComputeHash(password, passwordSalt, pepper, iteration);
            DateTime expectedCreateAt = DateTime.Now;
            DateTime expectedUpdateAt = DateTime.Now;

            User expectedUser = new User(expectedId, name, email, passwordSalt, passwordHash, expectedCreateAt, expectedUpdateAt);

            UserUpdateResource userUpdateResource = new UserUpdateResource(expectedId, updateName, email, password);

            ResponseDto<UserDto> expectedResponse = ResponseDto<UserDto>.Failure(500, "Error when updating user: The name must not be empty.");

            _mockUserRepository
                .Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedUser);

            ResponseDto<UserDto> responseUserDto = await _userService.Update(userUpdateResource, CancellationToken.None);

            responseUserDto.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task Update_WithEmptyEmail_ShouldReturnNoUser()
        {
            Guid expectedId = Guid.NewGuid();
            string name = _faker.Person.FullName;
            string email = _faker.Internet.Email();
            string updateEmail = "";
            string password = _faker.Internet.Password();

            string pepper = "45a31c6709be8c4fc946d3725c4be48a04053ca7c8ad7909985b2927e92ace4c";
            int iteration = 3;
            string passwordSalt = PasswordHelper.GenerateSalt();
            string passwordHash = PasswordHelper.ComputeHash(password, passwordSalt, pepper, iteration);
            DateTime expectedCreateAt = DateTime.Now;
            DateTime expectedUpdateAt = DateTime.Now;

            User expectedUser = new User(expectedId, name, email, passwordSalt, passwordHash, expectedCreateAt, expectedUpdateAt);

            UserUpdateResource userUpdateResource = new UserUpdateResource(expectedId, name, updateEmail, password);

            ResponseDto<UserDto> expectedResponse = ResponseDto<UserDto>.Failure(500, "Error when updating user: The email must not be empty.");

            _mockUserRepository
                .Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedUser);

            ResponseDto<UserDto> responseUserDto = await _userService.Update(userUpdateResource, CancellationToken.None);

            responseUserDto.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task Update_WithInvalidEmail_ShouldReturnNoUser()
        {
            Guid expectedId = Guid.NewGuid();
            string name = _faker.Person.FullName;
            string email = _faker.Internet.Email();
            string updateEmail = "123";
            string password = _faker.Internet.Password();

            string pepper = "45a31c6709be8c4fc946d3725c4be48a04053ca7c8ad7909985b2927e92ace4c";
            int iteration = 3;
            string passwordSalt = PasswordHelper.GenerateSalt();
            string passwordHash = PasswordHelper.ComputeHash(password, passwordSalt, pepper, iteration);
            DateTime expectedCreateAt = DateTime.Now;
            DateTime expectedUpdateAt = DateTime.Now;

            User expectedUser = new User(expectedId, name, email, passwordSalt, passwordHash, expectedCreateAt, expectedUpdateAt);

            UserUpdateResource userUpdateResource = new UserUpdateResource(expectedId, name, updateEmail, password);

            ResponseDto<UserDto> expectedResponse = ResponseDto<UserDto>.Failure(500, "Error when updating user: The email must be in a valid format.");

            _mockUserRepository
                .Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedUser);

            ResponseDto<UserDto> responseUserDto = await _userService.Update(userUpdateResource, CancellationToken.None);

            responseUserDto.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task Update_UnexpectedError_ShouldReturnCorrectlyUser()
        {
            Guid expectedId = Guid.NewGuid();
            string name = _faker.Person.FullName;
            string email = _faker.Internet.Email(name);
            string password = _faker.Internet.Password();

            UserUpdateResource userUpdateResource = new UserUpdateResource(expectedId, name, email, password);

            ResponseDto<UserDto> expectedResponse = ResponseDto<UserDto>.Failure(500, "Error when updating user.");

            _mockUserRepository
                .Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception());

            ResponseDto<UserDto> responseUserDto = await _userService.Update(userUpdateResource, CancellationToken.None);

            responseUserDto.Should().BeEquivalentTo(expectedResponse);
        }
        #endregion Update

        #region Delete
        [Fact]
        public async Task Delete_WithValidId_ShouldNotThrowException()
        {
            Guid expectedId = Guid.NewGuid();
            string name = _faker.Person.FullName;
            string email = _faker.Internet.Email(name);
            string password = _faker.Internet.Password();

            string pepper = "45a31c6709be8c4fc946d3725c4be48a04053ca7c8ad7909985b2927e92ace4c";
            int iteration = 3;
            string passwordSalt = PasswordHelper.GenerateSalt();
            string passwordHash = PasswordHelper.ComputeHash(password, passwordSalt, pepper, iteration);
            DateTime expectedCreateAt = DateTime.Now;
            DateTime expectedUpdateAt = DateTime.Now;

            User expectedUser = new User(expectedId, name, email, passwordSalt, passwordHash, expectedCreateAt, expectedUpdateAt);

            _mockUserRepository
                .Setup(x => x.Get(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedUser);

            Func<Task> add = async () => await _userService.Delete(email, CancellationToken.None);

            await add.Should().NotThrowAsync<DomainExceptionValidation>();
        }

        [Fact]
        public async Task Delete_GivenInvalidId_ThenShouldNotDelete()
        {
            string email = _faker.Internet.Email();

            ResponseDto<Guid> expectedResponse = ResponseDto<Guid>.Failure(400, "There is no user with this email.");

            _mockUserRepository
                .Setup(x => x.Get(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(null as User);

            ResponseDto<Guid> response = await _userService.Delete(email, CancellationToken.None);

            response.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task Delete_UnexpedtedError_ThenShouldThrowException()
        {
            string email = _faker.Internet.Email();

            ResponseDto<Guid> expectedResponse = ResponseDto<Guid>.Failure(500, "Error when deleting user.");

            _mockUserRepository
                .Setup(x => x.Get(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception());

            ResponseDto<Guid> response = await _userService.Delete(email, CancellationToken.None);

            response.Should().BeEquivalentTo(expectedResponse);
        }
        #endregion Delete
    }
}
