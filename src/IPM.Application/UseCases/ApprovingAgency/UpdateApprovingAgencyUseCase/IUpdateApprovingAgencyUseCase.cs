namespace IPM.Application.UseCases.ApprovingAgency.UpdateApprovingAgencyUseCase;

public interface IUpdateApprovingAgencyUseCase
{
    Task Handle(int id, UpdateApprovingAgencyRequest req);
}
