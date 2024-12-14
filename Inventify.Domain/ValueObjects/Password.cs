using System.Security.Cryptography;

namespace Inventify.Domain.ValueObjects
{
    public class Password
    {
        public Password()
        {

        }

        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 350000;
        private static readonly HashAlgorithmName _hashAlgorithm = HashAlgorithmName.SHA256;

        public string Hash { get; private set; }

        public Password(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be empty or whitespace.", nameof(password));
            }

            Hash = HashPassword(password);
        }

        private static string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                Iterations,
                _hashAlgorithm,
                KeySize);

            return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
        }

        public bool Verify(string password)
        {
            string[] parts = Hash.Split(':');
            if (parts.Length != 2)
            {
                throw new FormatException("Unexpected hash format. Should be formatted as `{salt}:{hash}`");
            }

            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] originalHash = Convert.FromBase64String(parts[1]);

            byte[] computedHash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                Iterations,
                _hashAlgorithm,
                originalHash.Length);

            return CryptographicOperations.FixedTimeEquals(originalHash, computedHash);
        }
    }
}