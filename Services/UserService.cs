using clinic_management_system.Dtos;
using clinic_management_system.Models;
using clinic_management_system.Repositories;

namespace clinic_management_system.Services
{
    public class UserService<T, TDto> : Service<TblUser, UserDto>
    {
        public UserService(IRepository<TblUser> repository, ILogger<Service<TblUser, UserDto>> logger) : base(repository, logger)
        {
        }

        protected override UserDto MapToDto(TblUser entity)
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

        protected override IEnumerable<UserDto> MapToDto(IEnumerable<TblUser> entities)
        {
            foreach (var entity in entities)
            {
                yield return new UserDto
                {
                    UserId = entity.UserId,
                    RoleId = entity.RoleId,
                    Username = entity.Username,
                    Password = entity.Password,
                    Email = entity.Email
                };
            }
        }

        protected override TblUser MapToEntity(UserDto dto)
        {
            return new TblUser
            {
                UserId = dto.UserId,
                RoleId = dto.RoleId,
                Username = dto.Username,
                Password = dto.Password,
                Email = dto.Email
            };
        }

        protected override TblUser UpdateEntityWithDto(TblUser entity, UserDto dto)
        {
            entity.UserId = dto.UserId;
            entity.RoleId = dto.RoleId;
            entity.Username = dto.Username;
            entity.Password = dto.Password;
            entity.Email = dto.Email;
            return entity;
        }
    }
}
