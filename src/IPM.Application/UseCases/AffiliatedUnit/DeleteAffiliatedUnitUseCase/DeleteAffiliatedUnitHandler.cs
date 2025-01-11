using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.AffiliatedUnit.DeleteAffiliatedUnitUseCase;

public class DeleteAffiliatedUnitHandler(IAffiliatedUnitRepository repo): IDeleteAffiliatedUnitUseCase
{
    public async Task Handle(int id)
    {
        await repo.Delete(id);
    }
}
