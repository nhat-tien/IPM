namespace IPM.Application.UseCases.Position.CreatePositionUseCase;

public interface ICreatePositionUseCase
{
  Task Handle(CreatePositionRequest req);
}
