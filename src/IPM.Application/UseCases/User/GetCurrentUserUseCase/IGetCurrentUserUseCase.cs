namespace IPM.Application.UseCases.User.GetCurrentUserUseCase;

public interface IGetCurrentUserUseCase
{
    Task<Domain.User?> Handle(string userId);
}