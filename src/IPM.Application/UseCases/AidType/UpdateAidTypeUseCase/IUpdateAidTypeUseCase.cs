namespace IPM.Application.UseCases.AidType.UpdateAidTypeUseCase;

public interface IUpdateAidTypeUseCase
{
    Task Handle(int id, UpdateAidTypeRequest req);
}
