using Bogus;
using FluentAssertions;
using InventifyBackend.Application.Helper;
using InventifyBackend.Domain.Entity;
using InventifyBackend.Domain.Validation;

namespace InventifyBackend.Tests.Entities
{
    public class UserTests
    {
        private readonly Faker _faker = new Faker("pt_BR");

        [Fact]
        public void Constructor_GivenAllParameters_ThenShouldSetPropertiesCorrectly()
        {
            //Arrange - onde arruma as informações
            Guid expectedId = Guid.NewGuid();
            string expectedName = _faker.Person.FullName;
            string expectedEmail = _faker.Internet.Email(expectedName);

            string password = _faker.Internet.Password();

            string pepper = "45a31c6709be8c4fc946d3725c4be48a04053ca7c8ad7909985b2927e92ace4c";
            int iteration = 3;
            string expectedPasswordSalt = PasswordHelper.GenerateSalt();
            string expectedPasswordHash = PasswordHelper.ComputeHash(password, expectedPasswordSalt, pepper, iteration);
            DateTime expectedCreateAt = DateTime.Now;
            DateTime expectedUpdateAt = DateTime.Now;

            //Act - executa algo do teste
            User user = new User(expectedId, expectedName, expectedEmail, expectedPasswordSalt, expectedPasswordHash, expectedCreateAt, expectedUpdateAt);

            //Assert - onde testa o que o valor deveria ser
            user.Id.Should().Be(expectedId);
            //Assert.Equal(expectedId, user.Id);
            user.Name.Should().Be(expectedName);
            //Assert.Equal(expectedName, user.Name);
            user.Email.Should().Be(expectedEmail);
            //Assert.Equal(expectedEmail, user.Email);
            user.PasswordSalt.Should().Be(expectedPasswordSalt);
            //Assert.Equal(expectedPasswordSalt, user.PasswordSalt);
            user.PasswordHash.Should().Be(expectedPasswordHash);
            //Assert.Equal(expectedPasswordHash, user.PasswordHash);
            user.CreatedAt.Should().Be(expectedCreateAt);
            //Assert.Equal(expectedCreateAt, user.CreatedAt);
            user.UpdatedAt.Should().Be(expectedUpdateAt);
            //Assert.Equal(expectedUpdateAt, user.UpdatedAt); 
        }

        [Fact]
        public void UpdateUser_GivenAllParameters_ThenShouldPropertiesCorrectly()
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

            User user = new User(expectedId, name, email, passwordSalt, passwordHash, expectedCreateAt, expectedUpdateAt);

            string expectedName = _faker.Person.FullName;
            string expectedEmail = _faker.Internet.Email(expectedName);

            string expectedPassword = _faker.Internet.Password();

            string expectedPasswordSalt = PasswordHelper.GenerateSalt();
            string expectedPasswordHash = PasswordHelper.ComputeHash(expectedPassword, expectedPasswordSalt, pepper, iteration);

            user.UpdateUser(expectedName, expectedEmail, expectedPasswordHash, expectedPasswordSalt);

            user.Name.Should().Be(expectedName);
            user.Email.Should().Be(expectedEmail);
            user.PasswordHash.Should().Be(expectedPasswordHash);
            user.PasswordSalt.Should().Be(expectedPasswordSalt);
        }

        [Fact]
        public void SetPasswordInfo_GivenAllParameters_ThenShouldPropertiesCorrectly()
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

            User user = new User(expectedId, name, email, passwordSalt, passwordHash, expectedCreateAt, expectedUpdateAt);

            string expectedPassword = _faker.Internet.Password();

            string expectedPasswordSalt = PasswordHelper.GenerateSalt();
            string expectedPasswordHash = PasswordHelper.ComputeHash(expectedPassword, expectedPasswordSalt, pepper, iteration);

            user.SetPasswordInfos(expectedPasswordHash, expectedPasswordSalt);

            user.PasswordHash.Should().Be(expectedPasswordHash);
            user.PasswordSalt.Should().Be(expectedPasswordSalt);
        }

        [Fact]
        public void ValidateUser_GivenAllParameters_ThenShouldNotThrowException()
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

            User user = new User(expectedId, name, email, passwordSalt, passwordHash, expectedCreateAt, expectedUpdateAt);

            Action validateUser = () => user.ValidateUser();

            validateUser.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void ValidateUser_GivenEmptyName_ThenShouldThrowException()
        {
            Guid expectedId = Guid.NewGuid();
            string name = "";
            string email = _faker.Internet.Email(name);

            string password = _faker.Internet.Password();

            string pepper = "45a31c6709be8c4fc946d3725c4be48a04053ca7c8ad7909985b2927e92ace4c";
            int iteration = 3;
            string passwordSalt = PasswordHelper.GenerateSalt();
            string passwordHash = PasswordHelper.ComputeHash(password, passwordSalt, pepper, iteration);
            DateTime expectedCreateAt = DateTime.Now;
            DateTime expectedUpdateAt = DateTime.Now;

            User user = new User(expectedId, name, email, passwordSalt, passwordHash, expectedCreateAt, expectedUpdateAt);

            Action validateUser = () => user.ValidateUser();

            validateUser.Should().Throw<DomainExceptionValidation>().WithMessage("The name must not be empty.");
        }

        [Fact]
        public void ValidateUser_GivenNullEmail_ThenShouldThrowException()
        {
            Guid expectedId = Guid.NewGuid();
            string name = _faker.Person.FullName;
            string email = null;

            string password = _faker.Internet.Password();

            string pepper = "45a31c6709be8c4fc946d3725c4be48a04053ca7c8ad7909985b2927e92ace4c";
            int iteration = 3;
            string passwordSalt = PasswordHelper.GenerateSalt();
            string passwordHash = PasswordHelper.ComputeHash(password, passwordSalt, pepper, iteration);
            DateTime expectedCreateAt = DateTime.Now;
            DateTime expectedUpdateAt = DateTime.Now;

            User user = new User(expectedId, name, email, passwordSalt, passwordHash, expectedCreateAt, expectedUpdateAt);

            Action validateUser = () => user.ValidateUser();

            validateUser.Should().Throw<DomainExceptionValidation>().WithMessage("The email must not be empty.");
        }

        [Fact]
        public void ValidateUser_GivenInvalidEmail_ThenShouldThrowException()
        {
            Guid expectedId = Guid.NewGuid();
            string name = _faker.Person.FullName;
            string email = "emailNaoValido";

            string password = _faker.Internet.Password();

            string pepper = "45a31c6709be8c4fc946d3725c4be48a04053ca7c8ad7909985b2927e92ace4c";
            int iteration = 3;
            string passwordSalt = PasswordHelper.GenerateSalt();
            string passwordHash = PasswordHelper.ComputeHash(password, passwordSalt, pepper, iteration);
            DateTime expectedCreateAt = DateTime.Now;
            DateTime expectedUpdateAt = DateTime.Now;

            User user = new User(expectedId, name, email, passwordSalt, passwordHash, expectedCreateAt, expectedUpdateAt);

            Action validateUser = () => user.ValidateUser();

            validateUser.Should().Throw<DomainExceptionValidation>().WithMessage("The email must be in a valid format.");
        }
    }
}
