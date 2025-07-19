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
            Console.WriteLine("[MinioException]: File Upload Error {0}", e.Message);
            return false;
        }
    }

    public async Task<bool> Delete(string objectName, string bucketName)
    {
        try
        {
            RemoveObjectArgs rmArgs = new RemoveObjectArgs()
                                          .WithBucket(bucketName)
                                          .WithObject(objectName);

            await minio.RemoveObjectAsync(rmArgs);

            return true;
        }
        catch (MinioException e)
        {
            Console.WriteLine("[MinioException]: Error " + e.Message);
            return false;
        }
    }


    public async Task<string?> Download(string objectName, string bucketName, string fileName)
    {
        try
        {
            string contentDisposition = $"attachment; filename=\"{fileName}\"";
            PresignedGetObjectArgs args = new PresignedGetObjectArgs()
                .WithBucket(bucketName)
                .WithObject(objectName)
                .WithHeaders(new Dictionary<string, string> {
                    { "response-content-disposition", contentDisposition }
                })
                .WithExpiry(60 * 15);

            string url = await minio.PresignedGetObjectAsync(args);

            return url;
        }
        catch (MinioException e)
        {
            Console.WriteLine("[MinioException]: File Upload Error {0}", e.Message);
            return null;
        }
    }
}
