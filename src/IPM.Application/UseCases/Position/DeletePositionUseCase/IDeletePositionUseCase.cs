namespace IPM.Application.UseCases.Position.DeletePositionUseCase;

public interface IDeletePositionUseCase
{
    Task Handle(int id);
}
