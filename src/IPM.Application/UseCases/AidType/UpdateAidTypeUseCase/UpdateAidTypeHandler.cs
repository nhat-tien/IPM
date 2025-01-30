using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.AidType.UpdateAidTypeUseCase;

public class UpdateAidTypeHandler(IAidTypeRepository repo) : IUpdateAidTypeUseCase
{
    public async Task Handle(int id, UpdateAidTypeRequest req)
    {
        Domain.AidType model = new Domain.AidType()
        {
            AidTypeId = id,
            AidTypeName = req.AidTypeName
        };
        await repo.UpdateAsync(model);
    }
}
