namespace IPM.Application.UseCases.Auth;

using IPM.Application.IRepositories;

public class LoginUseCase
{    
    private IUserRepository _userRepo;

    public LoginUseCase(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public void Execute()
    {
    }
}
