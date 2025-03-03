﻿using System.Security.Cryptography;
using System.Text;

namespace InventifyBackend.Application.Helper
{
    public static class PasswordHelper
    {
        public static string ComputeHash(string password, string salt, string pepper, int iteration)
        {
            if (iteration <= 0)
            {
                return password;
            }

            using SHA256 sha256 = SHA256.Create();
            string passwordSaltPepper = $"{password}{salt}{pepper}";
            byte[] byteValue = Encoding.UTF8.GetBytes(passwordSaltPepper);
            byte[] byteHash = sha256.ComputeHash(byteValue);
            string hash = Convert.ToBase64String(byteHash);
            return ComputeHash(hash, salt, pepper, iteration - 1);
        }

        public static string GenerateSalt()
        {
            using RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] byteSalt = new byte[16];
            rng.GetBytes(byteSalt);
            string salt = Convert.ToBase64String(byteSalt);
            return salt;
        }
    }
}
