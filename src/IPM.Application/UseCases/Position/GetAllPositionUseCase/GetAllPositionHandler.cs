using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Position.GetAllPositionUseCase;

public class GetAllPositionHandler(IPositionRepository repo): IGetAllPositionUseCase
{
    public async Task<IEnumerable<Domain.Position>> Handle()
    {
        return await repo.GetAll();
    }
}
