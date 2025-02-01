using InventifyBackend.Application.Contracts;
using InventifyBackend.Application.Maps;
using InventifyBackend.Application.Services;
using InventifyBackend.Domain.Contracts;
using InventifyBackend.Infra.Context;
using InventifyBackend.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventifyBackend.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
                this IServiceCollection services,
                IConfiguration configuration
            )
        {

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("InventifyConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                );

            services.AddAutoMapper(typeof(MapConfiguration));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGeneralRepository, GeneralRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}

