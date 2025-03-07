using IPM.Application.IRepositories;
using IPM.Application.IServices;
using IPM.Application.IUtils;

namespace IPM.Application.UseCases.User.UploadAvatarUseCase;

public class UploadAvatarHandler(IFileService fileService, IUserRepository repo): IUploadAvatarUseCase
{
    public async Task Handle(IFile avatar, string userId)
    {
        using (var streamData = new MemoryStream())
        {
            await avatar.CopyToAsync(streamData);
            streamData.Position = 0;

            var objectName = $"{userId}_{DateTime.UtcNow.ToString("dd-MM-yyyyTHH:mm:ss")}_{avatar.FileName}";

            var isSuccess = await fileService.Upload(
                streamData,
                avatar.Length,
                objectName,
                avatar.ContentType,
                "images"
            );

            if(!isSuccess) return;

            await repo.AddAvaterUrl(userId, objectName);
        }
    }
}
