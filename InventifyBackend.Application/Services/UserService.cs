using AutoMapper;
using InventifyBackend.Application.Configuration;
using InventifyBackend.Application.Contracts;
using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Helper;
using InventifyBackend.Domain.Contracts;
using InventifyBackend.Domain.Entity;
using Microsoft.Extensions.Options;

namespace InventifyBackend.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IGeneralRepository _generalRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly PasswordSettings _passwordSettings;
        private readonly int _iteration = 3;

        public UserService(IGeneralRepository generalRepository, IUserRepository userRepository, IMapper mapper, IOptions<PasswordSettings> passwordSettings)
        {
            _generalRepository = generalRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordSettings = passwordSettings.Value;
        }

        public async Task<ResponseDto<Guid>> Add(UserCreateResource userResource, CancellationToken cancellationToken)
        {
            try
            {
                User user = _mapper.Map<User>(userResource);

                if (await _userRepository.Get(user.Email) != null)
                {
                    return ResponseDto<Guid>.Failure(400, "There is already a user with this email.");
                }

                string passwordSalt = PasswordHelper.GenerateSalt();
                string passwordHash = PasswordHelper.ComputeHash(userResource.password, passwordSalt, _passwordSettings.Pepper, _iteration);

                user.SetPasswordInfos(passwordHash, passwordSalt);
                user.ValidateUser();

                await _generalRepository.Add(user, cancellationToken);

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
