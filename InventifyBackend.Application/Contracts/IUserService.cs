using InventifyBackend.Application.Dtos;

namespace InventifyBackend.Application.Contracts
{
    public interface IUserService
    {
        Task<ResponseDto<Guid>> Add(UserCreateResource userDto, CancellationToken cancellationToken);

        Task<ResponseDto<UserDto>> Get(string email);

        Task<ResponseDto<UserDto>> Update(UserUpdateResource userResource);

        Task<ResponseDto<Guid>> Delete(string email);
    }
}
