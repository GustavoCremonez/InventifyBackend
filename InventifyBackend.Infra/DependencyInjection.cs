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

            #region Auth Injections
            services.AddScoped<IAuthService, AuthService>();
            #endregion Auth Injections

            #region User Injections
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion User Injections

            #region Category Injections
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            #endregion Category Injections

            #region General Injections
            services.AddScoped<IGeneralRepository, GeneralRepository>();
            #endregion General Injections

            #region Customer Injections
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            #endregion CustomerInjections

            #region Product Injections

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            #endregion
            
            return services;
        }
    }
}

