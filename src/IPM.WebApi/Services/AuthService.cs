using IPM.Application.IServices;
using IPM.Application.UseCases.Auth.LoginUseCase;
using IPM.Application.UseCases.Auth.RegisterUseCase;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace IPM.WebApi.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public void Login(SignInRequest req)
    {
        throw new NotImplementedException();
    }

    public Task Register(RegisterRequest req)
    {
        throw new NotImplementedException();
    }
}
 
