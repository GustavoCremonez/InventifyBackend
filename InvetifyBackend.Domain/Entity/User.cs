using InventifyBackend.Domain.Validation;
using System.Text.RegularExpressions;

namespace InventifyBackend.Domain.Entity
{
    public sealed class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public void UpdateUser(string name, string email, string passwordHash)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;

            ValidateUser();
        }

        public void ValidateUser()
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(Name), "The name must not be empty.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(Email), "The email must not be empty.");

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(Email);

            DomainExceptionValidation.When(!match.Success, "The email must be in a valid format.");
        }
    }
}
