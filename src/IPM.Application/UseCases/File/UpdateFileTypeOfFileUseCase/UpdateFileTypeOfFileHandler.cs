
using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.File.UpdateFileTypeOfFileUseCase;

public class UpdateFileTypeOfFileHandler(IFileRepository fileRepo): IUpdateFileTypeOfFileUseCase
{
    public async Task Handle(int id, UpdateFileTypeOfFileRequest req)
    {
        Domain.File file = new Domain.File() {
            FileId = id,
            FileTypeId = Convert.ToInt32(req.fileTypeId)
        };

        await fileRepo.UpdateAsync(file);
    }
}
