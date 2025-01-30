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
             // options.UseNpgsql(configuration.GetConnectionString("WebApiDB"))
             options.UseNpgsql(new NpgsqlConnectStringBuilder {
                 Port = configuration["DbConfig:Post"]!,
                 Host = configuration["DbConfig:Server"]!,
                 User = configuration["DbConfig:User"]!,
                 Password = configuration["DbConfig:User"]!,
                 Database = configuration["DbConfig:Database"]!,
                 }.ConnectionString)
        );

        // services.AddScoped<IAppDBContext>(provider => provider.GetRequiredService<AppDBContext>());
        // services.AddSingleton<AppDBContext>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IApprovingAgencyRepository, ApprovingAgencyRepository>();
        services.AddScoped<IAffiliatedUnitRepository, AffiliatedUnitRepository>();
        services.AddScoped<IAidTypeRepository, AidTypeRepository>();
        services.AddScoped<ICurrencyUnitRepository, CurrencyUnitRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICounterpartyRepository, CounterpartyRepository>();
        services.AddScoped<IPositionRepository, PositionRepository>();
        services.AddScoped<ISponsorRepository, SponsorRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        return services;
    }
}
