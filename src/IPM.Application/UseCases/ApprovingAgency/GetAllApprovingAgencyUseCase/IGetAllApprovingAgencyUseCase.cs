namespace IPM.Application.UseCases.ApprovingAgency.GetAllApprovingAgencyUseCase;

public interface IGetAllApprovingAgencyUseCase
{
    Task<IEnumerable<Domain.ApprovingAgency>> Handle();
}
