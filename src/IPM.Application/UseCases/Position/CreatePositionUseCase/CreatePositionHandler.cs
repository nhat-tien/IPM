using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Position.CreatePositionUseCase;

public class CreatePositionHandler(IPositionRepository repo) : ICreatePositionUseCase
{
    public async Task Handle(CreatePositionRequest req)
    {
        Domain.Position entity = new Domain.Position() {
            PositionName = req.PositionName
        };
        await repo.Create(entity);
    }
}
