namespace IPM.Application.UseCases.AffiliatedUnit.CreateAffiliatedUnitUseCase;

public interface ICreateAffiliatedUnitUseCase
{
    Task Handle(CreateAffiliatedUnitRequest req);
}
