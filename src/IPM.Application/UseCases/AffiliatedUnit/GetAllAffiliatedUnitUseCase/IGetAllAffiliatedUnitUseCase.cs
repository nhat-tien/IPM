namespace IPM.Application.UseCases.AffiliatedUnit.GetAllAffiliatedUnitUseCase;

public interface IGetAllAffiliatedUnitUseCase
{
    Task<IEnumerable<Domain.AffiliatedUnit>> Handle();
}
