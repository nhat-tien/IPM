using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Auth.RegisterUseCase;

public class RegisterHandler(IUserRepository userRepo, IRoleRepository roleRepo) : IRegisterUseCase
{
    public async Task<RegisterResponse> Handle(RegisterRequest req)
    {
        var user = new Domain.User()
        {
            UserName = req.Email,
            // AffilatedUnitId = req.AffiliatedUnitId,
            // PositionId = req.PositionId,
            LastName = req.LastName,
            FirstName = req.FirstName,
            Email = req.Email,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
        var result = await userRepo.Create(user, req.Password);
        var role = await roleRepo.FindById(req.RoleId);
        if (role != null && role.RoleName != null)
        {
            await userRepo.AddToRole(user, role.RoleName);
        }
        ;
        if (result.IsSucceeded)
        {
            return RegisterResponse.Ok("Dang ki thanh cong");
        }
        else
        {
            return RegisterResponse.Error(result.Errors);
        }
    }
}
