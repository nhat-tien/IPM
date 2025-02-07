using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.FileType.CreateFileTypeUseCase;

public class CreateFileTypeHandler(IFileTypeRepository repo) : ICreateFileTypeUseCase
{
    public async Task Handle(CreateFileTypeRequest req)
    {
        Domain.FileType entity = new Domain.FileType() {
            FileTypeName = req.FileTypeName
        };
        await repo.AddAsync(entity);
    }
}
