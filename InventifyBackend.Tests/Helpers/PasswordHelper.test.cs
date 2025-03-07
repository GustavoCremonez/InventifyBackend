using Bogus;
using FluentAssertions;
using InventifyBackend.Application.Helper;
using System.Security.Cryptography;
using System.Text;

namespace InventifyBackend.Tests.Helpers
{
    public class PasswordHelperTests
    {
        private readonly Faker _faker = new("pt_BR");

        [Fact]
        public void ComputeHash_WhenIterationIsZero_ShouldReturnOriginalPassword()
        {
            // Arrange
            string password = _faker.Internet.Password();
            string salt = PasswordHelper.GenerateSalt();
            string pepper = _faker.Random.AlphaNumeric(64);
            int iteration = 0;

            // Act
            string result = PasswordHelper.ComputeHash(password, salt, pepper, iteration);

            // Assert
            result.Should().Be(password);
        }

        [Fact]
        public void ComputeHash_SingleIteration_ShouldComputeHashCorrectly()
        {
            // Arrange
            string password = _faker.Internet.Password();
            string salt = PasswordHelper.GenerateSalt();
            string pepper = _faker.Random.AlphaNumeric(64);
            int iteration = 1;

            // Act
            string result = PasswordHelper.ComputeHash(password, salt, pepper, iteration);

            // Assert
            using SHA256 sha256 = SHA256.Create();
            string expectedPasswordSaltPepper = $"{password}{salt}{pepper}";
            byte[] expectedByteValue = Encoding.UTF8.GetBytes(expectedPasswordSaltPepper);
            byte[] expectedByteHash = sha256.ComputeHash(expectedByteValue);
            string expectedHash = Convert.ToBase64String(expectedByteHash);

            result.Should().Be(expectedHash);
        }

        [Fact]
        public void ComputeHash_DifferentSalts_ShouldProduceDifferentHashes()
        {
            // Arrange
            string password = _faker.Internet.Password();
            string pepper = _faker.Random.AlphaNumeric(64);
            int iteration = 3;
            string salt1 = PasswordHelper.GenerateSalt();
            string salt2 = PasswordHelper.GenerateSalt();

            // Act
            string hash1 = PasswordHelper.ComputeHash(password, salt1, pepper, iteration);
            string hash2 = PasswordHelper.ComputeHash(password, salt2, pepper, iteration);

            // Assert
            hash1.Should().NotBe(hash2);
        }

        [Fact]
        public void ComputeHash_WithVeryLongPassword_ShouldComputeHashCorrectly()
        {
            // Arrange
            string longPassword = new('A', 1000000);
            string salt = PasswordHelper.GenerateSalt();
            string pepper = _faker.Random.AlphaNumeric(64);
            int iteration = 3;

            // Act
            string result = PasswordHelper.ComputeHash(longPassword, salt, pepper, iteration);

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().NotBe(longPassword);
            result.Length.Should().Be(44);
        }

        [Fact]
        public void GenerateSalt_ShouldGenerateDifferentSaltsOnConsecutiveCalls()
        {
            // Act
            string salt1 = PasswordHelper.GenerateSalt();
            string salt2 = PasswordHelper.GenerateSalt();
            string salt3 = PasswordHelper.GenerateSalt();

            // Assert
            salt1.Should().NotBeNullOrEmpty();
            salt2.Should().NotBeNullOrEmpty();
            salt3.Should().NotBeNullOrEmpty();

            salt1.Should().NotBe(salt2);
            salt1.Should().NotBe(salt3);
            salt2.Should().NotBe(salt3);
        }

        [Fact]
        public void GenerateSalt_CalledMultipleTimesInRapidSuccession_ShouldNotThrowException()
        {
            // Arrange
            const int numberOfCalls = 1000;
            Action generateSaltMultipleTimes = () =>
            {
                for (int i = 0; i < numberOfCalls; i++)
                {
                    PasswordHelper.GenerateSalt();
                }
            };

            // Act & Assert
            generateSaltMultipleTimes.Should().NotThrow();
        }

        [Fact]
        public void GenerateSalt_ShouldReturnNonNullAndNonEmptyString()
        {
            // Act
            string salt = PasswordHelper.GenerateSalt();

            // Assert
            salt.Should().NotBeNullOrEmpty();
        }
    }
}
