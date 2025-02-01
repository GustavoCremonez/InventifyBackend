using InventifyBackend.Application.Dtos;

namespace InventifyBackend.Application.Contracts
{
    public interface IUserService
    {
        Task<ResponseDto<Guid>> Add(UserDto userDto);

        Task<ResponseDto<UserDto>> Get(Guid id);

        Task<ResponseDto<UserDto>> Update(UserDto userDto);

        Task Delete(Guid id);
    }
}
