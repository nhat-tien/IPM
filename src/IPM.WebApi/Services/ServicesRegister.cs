using IPM.Application.IServices;
using IPM.Application.UseCases.Auth.LoginUseCase;
using IPM.Application.UseCases.Auth.RegisterUseCase;
using IPM.Infrastructure.EntityFrameworkDataAccess;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.AspNetCore.Authentication.BearerToken;
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
        services.AddOptions<BearerTokenOptions>(IdentityConstants.BearerScheme).Configure(options =>
        {
            options.BearerTokenExpiration = TimeSpan.FromDays(1);
        });

        services.AddScoped<IAuthService, AuthService>();
        return services;
    }

    public static IServiceCollection AddUseCaseServices(this IServiceCollection services)
    {
        services.AddScoped<ILoginUseCase, LoginHandler>();
        services.AddScoped<IRegisterUseCase, RegisterHandler>();
        return services;
    }
}
