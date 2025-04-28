using AutoMapper;
using InventifyBackend.Application.Configuration;
using InventifyBackend.Application.Contracts;
using InventifyBackend.Application.Dtos;
using InventifyBackend.Application.Dtos.User;
using InventifyBackend.Application.Helper;
using InventifyBackend.Domain.Contracts;
using InventifyBackend.Domain.Entity;
using InventifyBackend.Domain.Validation;
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

        public UserService(IGeneralRepository generalRepository, IUserRepository userRepository, IMapper mapper,
            IOptions<PasswordSettings> passwordSettings)
        {
            _generalRepository = generalRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordSettings = passwordSettings.Value;
        }

        public async Task<ResponseDto<Guid>> Add(UserCreateResource userResource, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<User>(userResource);

            if (await _userRepository.Get(user.Email, cancellationToken) != null)
            {
                return ResponseDto<Guid>.Failure(400, "There is already a user with this email.");
            }

            string passwordSalt = PasswordHelper.GenerateSalt();
            string passwordHash = PasswordHelper.ComputeHash(userResource.password, passwordSalt,
                _passwordSettings.Pepper, _iteration);

            user.SetPasswordInfos(passwordHash, passwordSalt);
            user.ValidateUser();

            await _generalRepository.Add(user, cancellationToken);

            return ResponseDto<Guid>.Success(user.Id);
        }

        public async Task<ResponseDto<UserDto>> Get(string email, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.Get(email, cancellationToken);

            if (user == null)
            {
                return ResponseDto<UserDto>.Failure(400, "There is no user with this email.");
            }

            UserDto userDto = _mapper.Map<UserDto>(user);

            return ResponseDto<UserDto>.Success(userDto);
        }

        public async Task<ResponseDto<UserDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.Get(id, cancellationToken);
            if (user == null)
            {
                return ResponseDto<UserDto>.Failure(404, "User not found.");
            }

            UserDto userDto = _mapper.Map<UserDto>(user);
            return ResponseDto<UserDto>.Success(userDto);
        }

        public async Task<ResponseDto<UserDto>> GetAbstracted(string email, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.Get(email, cancellationToken);

            if (user == null)
            {
                return ResponseDto<UserDto>.Failure(400, "There is no user with this email.");
            }

            UserDto userDto = _mapper.Map<UserDto>(user);

            userDto.PasswordHash = string.Empty;
            userDto.PasswordSalt = string.Empty;

            return ResponseDto<UserDto>.Success(userDto);
        }

        public async Task<ResponseDto<UserDto>> Update(UserUpdateResource userResource,
            CancellationToken cancellationToken)
        {
            if (userResource == null)
            {
                return ResponseDto<UserDto>.Failure(400, "The user information must contain a value.");
            }

            User? user = await _userRepository.Get(userResource.id, cancellationToken);

            if (user == null)
            {
                return ResponseDto<UserDto>.Failure(400, "There is no user with this email.");
            }

            string passwordSalt = PasswordHelper.GenerateSalt();
            string passwordHash = PasswordHelper.ComputeHash(userResource.password, passwordSalt,
                _passwordSettings.Pepper, _iteration);

            user.UpdateUser(userResource.name, userResource.email, passwordHash, passwordSalt);

            await _generalRepository.SaveAsync();

            UserDto userDto = _mapper.Map<UserDto>(user);

            return ResponseDto<UserDto>.Success(userDto);
        }

        public async Task<ResponseDto<Guid>> Delete(string email, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.Get(email, cancellationToken);

            if (user == null)
            {
                return ResponseDto<Guid>.Failure(400, "There is no user with this email.");
            }

            await _generalRepository.Delete(user);

            return ResponseDto<Guid>.Success(user.Id);
        }
    }
}