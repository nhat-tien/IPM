namespace IPM.Application.UseCases.AidType.CreateAidTypeUseCase;

public interface ICreateAidTypeUseCase
{
    Task Handle(CreateAidTypeRequest req);
}
