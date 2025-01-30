using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.AidType.GetAllAidTypeUseCase;

public class GetAllAidTypeHandler(IAidTypeRepository repo): IGetAllAidTypeUseCase
{
    public async Task<IEnumerable<Domain.AidType>> Handle()
    {
        return await repo.GetAllAsync();
    }
}
