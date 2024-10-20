using clinic_management_system.Common;
using clinic_management_system.Dtos;
using clinic_management_system.Models;
using clinic_management_system.Repositories;

namespace clinic_management_system.Services
{
    public class UserService : AbstractClass<TblUser, UserDto>, IService<UserDto>
    {
        private readonly IRepository<TblUser> _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IRepository<TblUser> userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task AddAsync(UserDto dto)
        {
            if (dto is null) throw new ArgumentNullException("User is null");
            dto.RoleId = dto.Username.ToUpper().Equals("ADMIN") ? 1 : 2;

            var newUser = MapDtoToEntity(dto);
            await _userRepository.AddAsync(newUser);
            _logger.LogInformation("Saved user successfully!");
        }

        public async Task DeleteAsync(object id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            if (user is null) throw new ArgumentNullException($"{nameof(user)} with id -> '{id}' not found.");

            await _userRepository.DeleteAsync(user);
            _logger.LogInformation("Deleted user successfully!");
        }

        public async Task<IEnumerable<UserDto>> FetchAllAsync()
        {
            var users = await _userRepository.FindAllAsync();
            if (users is null) throw new ArgumentNullException("Users not found");
            return users.Select(u => MapEntityToDto(u));
        }

        public async Task<UserDto> FetchByIdAsync(object id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            if (user is null) throw new ArgumentNullException($"{nameof(user)} with id -> '{id}' not found.");
            return MapEntityToDto(user);
        }

        public async Task UpdateAsync(object id, UserDto dto)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);
            if (existingUser is null) throw new ArgumentNullException($"{nameof(dto)} with id -> '{id}' not found.");

            existingUser.RoleId = dto.RoleId;
            existingUser.Username = dto.Username;
            existingUser.Password = dto.Password;
            existingUser.Email = dto.Email;
            await _userRepository.UpdateAsync(existingUser);
            _logger.LogInformation("Updated user successfully");
        }

        protected override TblUser MapDtoToEntity(UserDto dto)
        {
            return new TblUser
            {
                UserId = IdGenerator.GenerateUniqueId(),
                RoleId = dto.RoleId,
                Username = dto.Username,
                Password = dto.Password,
                Email = dto.Email
            };
        }

        protected override UserDto MapEntityToDto(TblUser entity)
        {
            return new UserDto
            {
                UserId = entity.UserId,
                RoleId = entity.RoleId,
                Username = entity.Username,
                Password = entity.Password,
                Email = entity.Email
            };
        }
    }
}
