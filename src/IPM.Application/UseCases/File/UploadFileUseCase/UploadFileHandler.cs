using IPM.Application.IRepositories;
using IPM.Application.IServices;
using IPM.Application.IUtils;

namespace IPM.Application.UseCases.File.UploadFileUseCase;

public class UploadFileHandler(IFileService fileService, IFileRepository repo) : IUploadFileUseCase
{
    public async Task Handle(IFile file, string fileTypeId, string projectId)
    {
        using (var streamData = new MemoryStream())
        {
            await file.CopyToAsync(streamData);
            streamData.Position = 0;
            var isSuccess = await fileService.Upload(
                streamData,
                file.Length,
                file.FileName,
                file.ContentType,
                "files"
            );

            if(!isSuccess) return;

            Domain.File fileInfo = new Domain.File() {
                FileName = file.FileName,
                FileTypeId = Convert.ToInt32(fileTypeId),
                ProjectId = Convert.ToInt32(projectId),
            };

            await repo.AddAsync(fileInfo);
        }
    }
}
