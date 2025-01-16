namespace IPM.Application.UseCases.Sponsor.CreateSponsorUseCase;

public interface ICreateSponsorUseCase
{
  Task Handle(CreateSponsorRequest req);
}
