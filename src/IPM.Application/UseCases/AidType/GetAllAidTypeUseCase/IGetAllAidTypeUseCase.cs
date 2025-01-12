namespace IPM.Application.UseCases.AidType.GetAllAidTypeUseCase;

public interface IGetAllAidTypeUseCase
{
    Task<IEnumerable<Domain.AidType>> Handle();
}
