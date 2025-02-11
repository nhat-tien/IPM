namespace IPM.Application.IServices;

public interface IFileService
{
    Task<bool> Upload(MemoryStream file, long fileSize, string fileName, string contentType, string bucketName);
}
