
namespace IPM.Application.UseCases.Auth.LoginUseCase;

public class LoginHandler: ILoginUseCase
{    
    public LoginHandler()
    {}

    public LoginResponse Execute(LoginRequest req)
    {
        return new LoginResponse();
    }
}
