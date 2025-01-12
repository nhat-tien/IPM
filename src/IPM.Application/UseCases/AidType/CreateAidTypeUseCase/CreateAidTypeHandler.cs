using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.AidType.CreateAidTypeUseCase;

public class CreateAidTypeHandler(IAidTypeRepository repo): ICreateAidTypeUseCase
{
    public async Task Handle(CreateAidTypeRequest req)
    {
        Domain.AidType model = new Domain.AidType() {
            AidTypeName = req.AidTypeName
        };
        await repo.Create(model);
    }
}
