namespace IPM.Application.UseCases.User.VerifyUserUseCase;

public interface IVerifyUserUseCase
{
    Task Handle(string userId);
}
