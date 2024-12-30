using IPM.Infrastructure.EntityFrameworkDataAccess;
using IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IPM.Application.IRepositories;

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

        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        return services;
    }
}
