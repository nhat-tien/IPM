using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.FileType.DeleteFileTypeUseCase;

public class DeleteFileTypeHandler(IFileTypeRepository repo): IDeleteFileTypeUseCase
{
    public async Task Handle(int id)
    {
        await repo.DeleteByIdAsync(id);
    }
}
