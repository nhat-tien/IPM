using IPM.Application.IServices;
using IPM.WebApi.Services;

namespace IPM.WebApi.ServiceRegisters;

public static class EmailServiceRegister
{
    public static IServiceCollection AddEmailService(
        this IServiceCollection services
    )
    {
        services.AddScoped<IEmailService, EmailService>();
        return services;
    }
}
