using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IPM.Infrastructure.EntityFrameworkDataAccess;

namespace IPM.Infrastructure;

public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContextPool<AppDBContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("WebApiDB")));

            services.AddScoped<IAppDBContext>(provider => provider.GetRequiredService<AppDBContext>());
            return services;
        }
    }