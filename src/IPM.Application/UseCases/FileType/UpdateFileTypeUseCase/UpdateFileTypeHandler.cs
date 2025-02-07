using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.FileType.UpdateFileTypeUseCase;

public class UpdateFileTypeHandler(IFileTypeRepository repo): IUpdateFileTypeUseCase
{
    public async Task Handle(int id, UpdateFileTypeRequest req)
    {
        Domain.FileType entity = new Domain.FileType()
        {
            FileTypeId = id,
            FileTypeName = req.FileTypeName
        };
        await repo.UpdateAsync(entity);
    }
}
