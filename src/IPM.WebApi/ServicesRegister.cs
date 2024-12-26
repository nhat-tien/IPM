using FluentValidation;
using IPM.Application.IServices;
using IPM.Application.UseCases.Auth.LoginUseCase;
using IPM.Application.UseCases.Auth.RegisterUseCase;
using IPM.Application.UseCases.Role;
using IPM.Infrastructure.EntityFrameworkDataAccess;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using IPM.WebApi.Services;
using Microsoft.AspNetCore.Identity;

namespace IPM.WebApi;

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
        services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDBContext>();
        // services.AddOptions<BearerTokenOptions>(IdentityConstants.BearerScheme).Configure(options =>
        // {
        //     options.BearerTokenExpiration = TimeSpan.FromDays(1);
        // });
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }

    public static IServiceCollection AddUseCaseServices(this IServiceCollection services)
    {
        services.AddScoped<ILoginUseCase, LoginHandler>();
        services.AddScoped<IRegisterUseCase, RegisterHandler>();
        services.AddScoped<IGetAllRoleUseCase, GetAllRoleUseCase>();
        return services;
    }

    public static IServiceCollection AddValidatorServices(this IServiceCollection services)
    {
        services.AddScoped<IValidator<RegisterRequest>, RegisterRequestValidator>();
        return services;
    }

}
