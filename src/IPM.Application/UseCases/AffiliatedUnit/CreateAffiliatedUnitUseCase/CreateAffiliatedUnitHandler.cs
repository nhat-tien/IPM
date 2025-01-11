using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.AffiliatedUnit.CreateAffiliatedUnitUseCase;

public class CreateAffiliatedUnitHandler(IAffiliatedUnitRepository repo) : ICreateAffiliatedUnitUseCase
{
    public async Task Handle(CreateAffiliatedUnitRequest req)
    {
        Domain.AffiliatedUnit model = new Domain.AffiliatedUnit() {
            AffiliatedUnitName = req.AffiliatedUnitName,
        };
        await repo.Create(model);
    }
}
