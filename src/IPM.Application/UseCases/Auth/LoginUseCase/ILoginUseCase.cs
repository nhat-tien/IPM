namespace IPM.Application.UseCases.Auth.LoginUseCase;

public interface ILoginUseCase
{
    Task<SignInResponse> Handle(SignInRequest req);
}
