using IPM.Application.IServices;
using IPM.Application.UseCases.Auth.LoginUseCase;
using IPM.Infrastructure.EntityFrameworkDataAccess;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace IPM.WebApi.Services;

public static class ServiceRegister
{
    public static IServiceCollection AddAuthServices(this IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddAuthentication();
        //.AddBearerToken(IdentityConstants.BearerScheme);
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
        });
        services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<AppDBContext>();

        services.AddScoped<IAuthService, AuthService>();
        return services;
    }

    public static IServiceCollection AddUseCaseServices(this IServiceCollection services)
    {
        services.AddSingleton<ILoginUseCase, LoginHandler>();
        return services;
    }
}