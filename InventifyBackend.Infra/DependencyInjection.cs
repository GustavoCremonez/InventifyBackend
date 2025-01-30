using InventifyBackend.Application.Maps;
using InventifyBackend.Infra.Context;
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
            //services.AddScoped<IUserService, IUserService>();

            return services;
        }
    }
}

