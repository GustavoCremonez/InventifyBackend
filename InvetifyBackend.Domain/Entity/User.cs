using InventifyBackend.Domain.Validation;
using System.Text.RegularExpressions;

namespace InventifyBackend.Domain.Entity
{
    public sealed class User
    {
        public User(Guid id, string name, string email, string passwordSalt, string passwordHash, DateTime? createdAt, DateTime? updatedAt)
        {
            Id = id;
            Name = name;
            Email = email;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        protected User()
        {

        }


        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string PasswordSalt { get; private set; }

        public string PasswordHash { get; private set; }

        public DateTime? CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public void UpdateUser(string name, string email, string passwordHash, string passwordSalt)
        {
            Name = name;
            Email = email;

            SetPasswordInfos(passwordHash, PasswordSalt);
            ValidateUser();
        }

        public void SetPasswordInfos(string passwordHash, string passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        public void ValidateUser()
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(Name), "The name must not be empty.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(Email), "The email must not be empty.");

            Regex regex = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(Email);

            DomainExceptionValidation.When(!match.Success, "The email must be in a valid format.");
        }
    }
}
