using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.AffiliatedUnit.UpdateAffiliatedUnitUseCase;

public class UpdateAffiliatedUnitHandler(IAffiliatedUnitRepository repo)
    : IUpdateAffiliatedUnitUseCase
{
    public async Task Handle(int id, UpdateAffiliatedUnitRequest req)
    {
        Domain.AffiliatedUnit model = new Domain.AffiliatedUnit()
        {
            AffiliatedUnitId = id,
            AffiliatedUnitName = req.AffiliatedUnitName,
        };
        await repo.Update(model);
    }
}
