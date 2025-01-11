namespace IPM.Application.UseCases.ApprovingAgency.CreateApprovingAgencyUseCase;

public interface ICreateApprovingAgencyUseCase
{
    Task Handle(CreateApprovingAgencyRequest req);
}
