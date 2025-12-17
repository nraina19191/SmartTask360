using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTask.UserService.Domain;

namespace SmartTask.UserService.Infrastructure.Configurations
{
    internal class UserConfig : IEntityTypeConfiguration<Domain.User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(500);
            builder.Property(x => x.Email).HasMaxLength(500);
        }
    }
}
