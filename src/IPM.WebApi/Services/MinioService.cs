using IPM.Application.IServices;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;

namespace IPM.WebApi.Services;

public class MinioService(IMinioClient minio) : IFileService
{
    public async Task<bool> Upload(
        MemoryStream file,
        long fileSize,
        string fileName,
        string contentType,
        string bucketName
    )
    {
        try
        {
            PutObjectArgs poa = new PutObjectArgs()
                .WithBucket(bucketName)
                .WithObject(fileName)
                .WithObjectSize(fileSize)
                .WithStreamData(file)
                .WithContentType(contentType);

            await minio.PutObjectAsync(poa);

            return true;
        }
        catch (MinioException e)
        {
            Console.WriteLine("File Upload Error: {0}", e.Message);
            return false;
        }
    }
}
