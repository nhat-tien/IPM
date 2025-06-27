
namespace IPM.Application.IServices;

public interface IFileService
{
    Task<bool> Upload(MemoryStream file, long fileSize, string fileName, string contentType, string bucketName);
    Task<bool> Delete(string objectName, string bucketName);
    Task<string?> Download(string objectName, string bucketName);
}
