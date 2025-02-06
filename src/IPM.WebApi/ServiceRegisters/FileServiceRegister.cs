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
                .WithEndpoint(configuration["Minio:EndPoint"])
                .WithCredentials(configuration["Minio:AccessKey"], configuration["Minio:SecretKey"])
                .Build()
        );
        services.AddScoped<IFileService, FileService>();
        return services;
    }
}
