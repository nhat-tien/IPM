using IPM.Infrastructure.EntityFrameworkDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IPM.Infrastructure;

public static class InfrastructureService
{
    public static IServiceCollection AddPersistenceService(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContextPool<AppDBContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("WebApiDB"))
        );
        services.AddScoped<IAppDBContext>(provider => provider.GetRequiredService<AppDBContext>());
        return services;
    }
}
