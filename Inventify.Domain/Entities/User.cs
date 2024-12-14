using Inventify.Domain.ValueObjects;

namespace Inventify.Domain.Entities
{
    public class User
    {
        public User(string name, Email email, Password password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        protected User() { }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public Email Email { get; private set; }

        public Password Password { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("Name cannot be empty or whitespace.", nameof(newName));
            }

            Name = newName;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateEmail(Email newEmail)
        {
            Email = newEmail ?? throw new ArgumentNullException(nameof(newEmail));
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdatePassword(Password newPassword)
        {
            Password = newPassword ?? throw new ArgumentNullException(nameof(newPassword));
            UpdatedAt = DateTime.UtcNow;
        }
    }
}