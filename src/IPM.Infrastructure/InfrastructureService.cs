using IPM.Infrastructure.EntityFrameworkDataAccess;
using IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IPM.Application.IRepositories;
using IPM.Application.IUnitOfWorks;

namespace IPM.Infrastructure;

public static class InfrastructureService
{
    public static IServiceCollection AddPersistenceService(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContextPool<AppDBContext>(options =>
             options.UseNpgsql(new NpgsqlConnectStringBuilder {
                 Port = configuration["DbConfig:Post"]!,
                 Host = configuration["DbConfig:Server"]!,
                 User = configuration["DbConfig:User"]!,
                 Password = configuration["DbConfig:User"]!,
                 Database = configuration["DbConfig:Database"]!,
                 }.ConnectionString)
        );

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
        services.AddScoped<IFileTypeRepository, FileTypeRepository>();
        services.AddScoped<IFileRepository, FileRepository>();
        services.AddScoped<IParticipationRepository, ParticipationRepository>();
        services.AddScoped<IAuditLogRepository, AuditLogRepository>();

        services.AddScoped<IProjectUnitOfWork, ProjectUnitOfWork>();
        return services;
    }
}
