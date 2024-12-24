namespace IPM.Application.UseCases.Auth.LoginUseCase;

public interface ILoginUseCase
{
    SignInResponse Execute(SignInRequest req);
}
