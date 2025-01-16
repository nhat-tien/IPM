namespace IPM.Application.UseCases.Sponsor.DeleteSponsorUseCase;

public interface IDeleteSponsorUseCase
{
    Task Handle(int id);
}
