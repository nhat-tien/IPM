namespace IPM.Application.UseCases.Sponsor.GetAllSponsorUseCase;

public interface IGetAllSponsorUseCase
{
    Task<IEnumerable<Domain.Sponsor>> Handle();
}
