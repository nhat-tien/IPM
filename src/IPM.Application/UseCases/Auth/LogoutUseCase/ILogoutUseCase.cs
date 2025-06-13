namespace IPM.Application.UseCases.Auth.LogoutUseCase;

public interface ILogoutUseCase
{
    Task Handle(string refreshToken);
}
