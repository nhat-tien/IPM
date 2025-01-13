namespace IPM.Application.UseCases.User.GetAllUserUseCase;

public interface IGetAllUserUseCase
{
    Task<IEnumerable<Domain.User>> Handle();
}
