using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartTask.UserService.Application.Commands;

namespace SmartTask.UserService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<CreateUserCommand>();
                cfg.LicenseKey = configuration["Mediatr:LicenseKey"];
            });

            return services;
        }
    }
}
