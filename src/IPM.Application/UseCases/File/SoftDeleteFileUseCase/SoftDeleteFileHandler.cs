using IPM.Application.IRepositories;
using IPM.Application.IServices;

namespace IPM.Application.UseCases.File.SoftDeleteFileUseCase;

public class SoftDeleteFileHandler(IFileService fileService, IFileRepository repo):  ISoftDeleteFileUseCase
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
