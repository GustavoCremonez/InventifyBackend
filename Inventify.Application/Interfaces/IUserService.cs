using Inventify.Application.Dtos;
using Inventify.Domain.ValueObjects;

namespace Inventify.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetByIdAsync(Guid id);

        Task<UserDto> GetByEmailAsync(Email email);

        Task<int> CreateUserAsync(UserDto user);

        Task<int> UpdateUserAsync(UserDto user);

        Task DeleteUserAsync(Guid id);
    }
}
