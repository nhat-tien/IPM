using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Position.UpdatePositionUseCase;

public class UpdatePositionHandler(IPositionRepository repo) : IUpdatePositionUseCase
{
    public async Task Handle(int id, UpdatePositionRequest req)
    {
        Domain.Position entity = new Domain.Position()
        {
            PositionId = id,
            PositionName = req.PositionName
        };
        await repo.UpdateAsync(entity);
    }
}
