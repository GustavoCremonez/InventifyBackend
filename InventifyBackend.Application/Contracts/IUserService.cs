using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.User;

namespace InventifyBackend.Application.Contracts
{
    public interface IUserService
    {
        Task<ResponseDto<Guid>> Add(UserCreateResource userDto, CancellationToken cancellationToken);

        Task<ResponseDto<UserDto>> Get(string email, CancellationToken cancellationToken);

        Task<ResponseDto<UserDto>> GetAbstracted(string email, CancellationToken cancellationToken);

        Task<ResponseDto<UserDto>> Update(UserUpdateResource userResource, CancellationToken cancellationToken);

        Task<ResponseDto<Guid>> Delete(string email, CancellationToken cancellationToken);
    }
}
