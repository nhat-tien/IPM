using IPM.Application.IServices;
using IPM.Application.UseCases.Auth.LoginUseCase;
using IPM.Application.UseCases.Auth.RegisterUseCase;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace IPM.WebApi.Services;

public class AuthService(
    UserManager<User> userManager,
    JwtService jwtService,
    RoleManager<IdentityRole> roleManager
) : IAuthService
{
    public async Task<SignInResponse> Login(SignInRequest req) 
    { 
        User? user = await userManager.FindByNameAsync(req.Email);
        if(user is null)
        {
            return SignInResponse.Error("User was not found");
        }
        bool verify = await userManager.CheckPasswordAsync(user, req.Password);
        if(!verify)
        {
            return SignInResponse.Error("Password incorrect");
        }
        string token = jwtService.Create(user);

        return SignInResponse.Ok("Success", token);

    }

    public async Task<RegisterResponse> Register(RegisterRequest req)
    {
        var user = new User()
        {
            UserName = req.Email,
            AffilatedUnitId = req.AffiliatedUnitId,
            PositionId = req.PositionId,
            LastName = req.LastName,
            FirstName = req.FirstName,
            Email = req.Email,
        };
        var result = await userManager.CreateAsync(user, req.Password);
        var role = await roleManager.FindByIdAsync(req.RoleId);

        if (role != null && role.Name != null)
        {
            await userManager.AddToRoleAsync(user, role.Name);
        }
        ;
        if (result.Succeeded)
        {
            return RegisterResponse.Ok("Dang ki thanh cong");
        }
        else
        {
            return RegisterResponse.Error(GetRegisterErrors(result));
        }
    }

    private Dictionary<string, string[]> GetRegisterErrors(IdentityResult result)
    {
        var errorDictionary = new Dictionary<string, string[]>(1);

        foreach (var error in result.Errors)
        {
            string[] newDescriptions;

            if (errorDictionary.TryGetValue(error.Code, out var descriptions))
            {
                newDescriptions = new string[descriptions.Length + 1];
                Array.Copy(descriptions, newDescriptions, descriptions.Length);
                newDescriptions[descriptions.Length] = error.Description;
            }
            else
            {
                newDescriptions = [error.Description];
            }

            errorDictionary[error.Code] = newDescriptions;
        }

        return errorDictionary;
    }
}
