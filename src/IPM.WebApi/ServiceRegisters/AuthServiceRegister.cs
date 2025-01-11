using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using IPM.Infrastructure.EntityFrameworkDataAccess;
using IPM.Application.IServices;
using IPM.WebApi.Services;

namespace IPM.WebApi.ServiceRegisters;

public static class AuthServiceRegister
{
    public static IServiceCollection AddAuthServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddAuthentication(o => {
                  o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]!)
                    ),
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    ClockSkew = TimeSpan.Zero,
                };
                // o.Events = new JwtBearerEvents
                // {
                //     OnMessageReceived = ctx => 
                //     {
                //        ctx.Request.Cookies.TryGetValue("AccessToken", out var accessToken);
                //        if(!string.IsNullOrEmpty(accessToken))
                //        {
                //            ctx.Token = accessToken;
                //        }
                //        return Task.CompletedTask;
                //     }
                // };
                //
            });
        services.AddAuthorizationBuilder()
            .AddPolicy("admin_permission", policy => policy.RequireRole("Admin"))
            .AddPolicy("manager_permission", policy => policy.RequireRole("Admin","Manager"))
            .AddPolicy("user_permission", policy => policy.RequireRole("Admin","Manager","User"));

        //.AddBearerToken(IdentityConstants.BearerScheme);
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
        });
        services
            .AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDBContext>();
        // services.AddOptions<BearerTokenOptions>(IdentityConstants.BearerScheme).Configure(options =>
        // {
        //     options.BearerTokenExpiration = TimeSpan.FromDays(1);
        // });
        services.AddScoped<IAuthService, JwtService>();
        return services;
    }
}
