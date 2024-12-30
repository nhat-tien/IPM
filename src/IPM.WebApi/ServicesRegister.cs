using System.Reflection;
using System.Text;
using FluentValidation;
using IPM.Application.IServices;
using IPM.Application.UseCases.Auth.LoginUseCase;
using IPM.Application.UseCases.Auth.RefreshTokenUseCase;
using IPM.Application.UseCases.Auth.RegisterUseCase;
using IPM.Application.UseCases.Role;
using IPM.Infrastructure.EntityFrameworkDataAccess;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using IPM.WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace IPM.WebApi;

public static class ServiceRegister
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
        services.AddAuthorization();
        //.AddBearerToken(IdentityConstants.BearerScheme);
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
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

    public static IServiceCollection AddSwaggerGenWithAuth(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.CustomSchemaIds(id => id.FullName!.Replace("+", "-"));
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "JWT Auth",
                Description = "Enter JWT Token",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                BearerFormat = "JWT",
            };
            c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);

            var securityRequirement = new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme,
                        },
                    },
                    []
                },
            };
            c.AddSecurityRequirement(securityRequirement);

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
        return services;
    }

    public static IServiceCollection AddUseCaseServices(this IServiceCollection services)
    {
        services.AddScoped<ILoginUseCase, LoginHandler>();
        services.AddScoped<IRegisterUseCase, RegisterHandler>();
        services.AddScoped<IRefreshTokenUseCase, RefreshTokenHandler>();
        services.AddScoped<IGetAllRoleUseCase, GetAllRoleUseCase>();
        return services;
    }

    public static IServiceCollection AddValidatorServices(this IServiceCollection services)
    {
        services.AddScoped<IValidator<RegisterRequest>, RegisterRequestValidator>();
        services.AddScoped<IValidator<SignInRequest>, SignInRequestValidator>();
        return services;
    }
}
