using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SmartTask.UserService.Infrastructure.Db
{
    public class UserDbContextFactory : IDesignTimeDbContextFactory<UserDbContext>
    {
        public UserDbContextFactory()
        {
        }

        public UserDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

            return new UserDbContext(new DbContextOptionsBuilder<UserDbContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection")).Options);
        }
    }
}
