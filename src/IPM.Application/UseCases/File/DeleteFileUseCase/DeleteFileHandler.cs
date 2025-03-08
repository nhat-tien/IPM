using IPM.Application.IRepositories;
using IPM.Application.IServices;

namespace IPM.Application.UseCases.File.DeleteFileUseCase;

public class DeleteFileHandler(IFileService fileService, IFileRepository repo): IDeleteFileUseCase
{
    public async Task Handle(int fileId)
    {
        var fileObj = await repo.FindByIdAsync(fileId);

        if(fileObj is null) {
            return;
        }
        if(fileObj.ObjectName is null) {
            return;
        }

        var isSuccess = await fileService.Delete(fileObj.ObjectName, "files");

        if(!isSuccess) {
            return;
        }

        await repo.DeleteByIdAsync(fileObj.FileId);
    }
}
