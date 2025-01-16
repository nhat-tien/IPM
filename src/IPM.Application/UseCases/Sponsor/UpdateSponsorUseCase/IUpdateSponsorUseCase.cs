namespace IPM.Application.UseCases.Sponsor.UpdateSponsorUseCase;

public interface IUpdateSponsorUseCase
{
    Task Handle(int id, UpdateSponsorRequest req);
}
