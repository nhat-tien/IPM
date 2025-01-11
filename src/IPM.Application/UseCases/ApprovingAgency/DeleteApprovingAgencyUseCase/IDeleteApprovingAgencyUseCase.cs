namespace IPM.Application.UseCases.ApprovingAgency.DeleteApprovingAgencyUseCase;

public interface IDeleteApprovingAgencyUseCase
{
    Task Handle(int id);
}
