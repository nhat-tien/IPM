namespace IPM.Application.UseCases.AffiliatedUnit.UpdateAffiliatedUnitUseCase;

public interface IUpdateAffiliatedUnitUseCase
{
    Task Handle(int id, UpdateAffiliatedUnitRequest req);
}
