namespace IPM.Application.UseCases.Position.GetAllPositionUseCase;

public interface IGetAllPositionUseCase
{
    Task<IEnumerable<Domain.Position>> Handle();
}
