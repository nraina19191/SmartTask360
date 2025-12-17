using SmartTask.Base;

namespace SmartTask.UserService.Domain
{
    public class User : BaseAuditableEntity
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
    }
}
