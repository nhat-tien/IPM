using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Position.DeletePositionUseCase;

public class DeletePositionHandler(IPositionRepository repo): IDeletePositionUseCase
{
    public async Task Handle(int id)
    {
        await repo.Delete(id);
    }
}
