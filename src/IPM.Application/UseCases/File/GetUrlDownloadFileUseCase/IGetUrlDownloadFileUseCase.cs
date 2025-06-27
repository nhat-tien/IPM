namespace IPM.Application.UseCases.File.GetUrlDownloadFileUseCase;

public interface IGetUrlDownloadFileUseCase
{
    Task<UrlDownloadFileResponse?> Handle(int projectId);
}
