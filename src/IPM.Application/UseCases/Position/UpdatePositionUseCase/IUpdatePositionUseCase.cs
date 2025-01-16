namespace IPM.Application.UseCases.Position.UpdatePositionUseCase;

public interface IUpdatePositionUseCase
{
    Task Handle(int id, UpdatePositionRequest req);
}
