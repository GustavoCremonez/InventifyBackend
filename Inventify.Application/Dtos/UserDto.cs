using Inventify.Domain.ValueObjects;

namespace Inventify.Application.Dtos
{
    public class UserDto
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public Email Email { get; private set; }

        public Password Password { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }
    }
}
