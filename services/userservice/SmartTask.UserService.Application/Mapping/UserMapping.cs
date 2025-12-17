using SmartTask.UserService.Application;
using SmartTask.UserService.Domain;

namespace SmartTask.UserService.Application.Mapping
{
    public static class UserMapping
    {
        public static User MapToEntity(this UserDto userDto)
        {
            ArgumentNullException.ThrowIfNull(userDto, nameof(userDto));

            var entity = new User();
            entity.Id = userDto.Id;
            entity.Email = userDto.Email;
            entity.PasswordHash = userDto.Password;

            return entity;
        }

        public static UserDto MapToDto(this User user)
        {
            ArgumentNullException.ThrowIfNull(user, nameof(user));

            return new UserDto(user.Id, user.Name, user.Email, user.PasswordHash);
        }
    }
}
