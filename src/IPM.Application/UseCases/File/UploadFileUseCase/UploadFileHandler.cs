using IPM.Application.IServices;
using IPM.Application.IUtils;

namespace IPM.Application.UseCases.File.UploadFileUseCase;

public class UploadFileHandler(IFileService fileService) : IUploadFileUseCase
{
    public async Task Handle(
        IFile file,
        string fileTypeId,
        string projectId
    )
    {
        using(var streamData = new MemoryStream()) 
        {
            await file.CopyToAsync(streamData);
            streamData.Position = 0;
            await fileService.Upload(streamData, file.Length, file.FileName, file.ContentType, "files-bucket");
        }
    }
}
