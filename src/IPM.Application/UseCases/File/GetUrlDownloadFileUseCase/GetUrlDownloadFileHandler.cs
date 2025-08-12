using IPM.Application.IRepositories;
using IPM.Application.IServices;

namespace IPM.Application.UseCases.File.GetUrlDownloadFileUseCase;

public class GetUrlDownloadFileHandler(IFileService fileService, IFileRepository fileRepo): IGetUrlDownloadFileUseCase
{
    public async Task<UrlDownloadFileResponse?> Handle(int fileId)
    {
        Domain.File? file = await fileRepo.FindByIdAsync(fileId);

        if(file is null || file.FileName is null || file.Extension is null) 
        {
            return null;
        }

        string? presignUrl = await fileService.Download(file.ObjectName!, "files", $"{file.FileName}.{file.Extension}");

        if(presignUrl is null)
        {
            return null;
        }

        return new UrlDownloadFileResponse()
        {
            Url = presignUrl,
            Name = file.FileName,
            Extension = file.Extension 
        };

    }
}
