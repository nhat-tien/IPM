using IPM.Application.IServices;
using IPM.Application.UseCases.Auth.LoginUseCase;
using IPM.Application.UseCases.Auth.RegisterUseCase;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace IPM.WebApi.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;
    private readonly RoleManager<IdentityRole> roleManager;

    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.roleManager = roleManager;
    }

    public void Login(SignInRequest req)
    {
        throw new NotImplementedException();
    }

    public async Task<AuthResultDto> Register(RegisterRequest req)
    {
        var user = new User() {
            UserName = req.Email,
            AffilatedUnitId = req.AffiliatedUnitId,
            PositionId = req.PositionId,
            LastName = req.LastName,
            FirstName = req.FirstName,
            Email = req.Email,
        };
        var result = await userManager.CreateAsync(user, req.Password);
        var role = await roleManager.FindByIdAsync(req.RoleId);

        if(role != null && role.Name != null)
        {
            await userManager.AddToRoleAsync(user,role.Name);
        };
        if(result.Succeeded)
        {
            return new AuthResultDto(true, null);
        } 
        else 
        {
            return new AuthResultDto(false,GetRegisterErrors(result));
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
 
