using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.FileType.GetAllFileTypeUseCase;

public class GetAllFileTypeHandler(IFileTypeRepository repo): IGetAllFileTypeUseCase
{
    public async Task<IEnumerable<Domain.FileType>> Handle()
    {
        return await repo.GetAllAsync();
    }
}
