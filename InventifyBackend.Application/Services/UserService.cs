using AutoMapper;
using InventifyBackend.Application.Contracts;
using InventifyBackend.Application.Dtos;
using InventifyBackend.Domain.Contracts;
using InventifyBackend.Domain.Entity;

namespace InventifyBackend.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IGeneralRepository _generalRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IGeneralRepository generalRepository, IUserRepository userRepository, IMapper mapper)
        {
            _generalRepository = generalRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<Guid>> Add(UserDto userDto)
        {
            try
            {
                User user = _mapper.Map<User>(userDto);

                if (await _userRepository.Get(user.Email) != null)
                {
                    return ResponseDto<Guid>.Failure(400, "There is already a user with this email.");
                }

                user.PasswordHash = new Guid().ToString();
                user.ValidateUser();

                await _generalRepository.Add(user);

                return ResponseDto<Guid>.Success(user.Id);
            }
            catch (Exception e)
            {
                return ResponseDto<Guid>.Failure(500, "Error when registering user." + e.Message);
            }
        }

        public async Task<ResponseDto<UserDto>> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto<UserDto>> Update(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
