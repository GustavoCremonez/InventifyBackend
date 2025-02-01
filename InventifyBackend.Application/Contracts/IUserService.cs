using InventifyBackend.Application.Dtos;

namespace InventifyBackend.Application.Contracts
{
    public interface IUserService
    {
        Task<ResponseDto<Guid>> Add(UserCreateResource userDto, CancellationToken cancellationToken);

        Task<ResponseDto<UserDto>> Get(Guid id);

        Task<ResponseDto<UserDto>> Update(UserDto userDto);

        Task Delete(Guid id);
    }
}
