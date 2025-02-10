using IPM.Application.IServices;
using IPM.WebApi.Services;
using Minio;

namespace IPM.WebApi.ServiceRegisters;

public static class FileServiceRegister
{
    public static IServiceCollection AddFileService(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddMinio(configureClient =>
            configureClient
                .WithEndpoint(configuration["Minio:EndPoint"], 9000)
                .WithCredentials(configuration["Minio:AccessKey"], configuration["Minio:SecretKey"])
                //WARN: Without SSL
                .WithSSL(false)
                .Build()
        );

        services.AddScoped<IFileService, MinioService>();
        return services;
    }
}
