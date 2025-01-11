using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.AffiliatedUnit.GetAllAffiliatedUnitUseCase;

public class GetAllAffiliatedUnitHandler(IAffiliatedUnitRepository repo): IGetAllAffiliatedUnitUseCase
{
    public async Task<IEnumerable<Domain.AffiliatedUnit>> Handle()
    {
        return await repo.GetAll();
    }
}
