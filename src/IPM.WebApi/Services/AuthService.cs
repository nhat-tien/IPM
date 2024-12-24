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

    public async Task Register(RegisterRequest req)
    {
        var userCheck = await _userManager.FindByEmailAsync(req.Email);
        if(userCheck != null)
        {

        };

        var user 
    }
    public void Login(LoginRequest req)
    {
        throw new NotImplementedException();
    }
}
 
