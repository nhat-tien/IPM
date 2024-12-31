using FluentValidation;
using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Auth.RegisterUseCase;

public class RegisterHandler(IUserRepository userRepo, IRoleRepository roleRepo): IRegisterUseCase
{
    public async Task<RegisterResponse> Handle(RegisterRequest req)
    {
        var user = new Domain.User()
        {
            UserName = req.Email,
            AffilatedUnitId = req.AffiliatedUnitId,
            PositionId = req.PositionId,
            LastName = req.LastName,
            FirstName = req.FirstName,
            Email = req.Email,
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

public class RegisterResponse {
    public bool IsSuccess {get; private set;}
    public string? Message {get; private set;}
    public Dictionary<string, string[]>? Errors {get; private set;}

    public static RegisterResponse Ok(string message)
    {
        return new RegisterResponse() {
            IsSuccess = true,
            Errors = null,
            Message = message
        };
    }

    public static RegisterResponse Error(Dictionary<string, string[]>? errors)
    {
        return new RegisterResponse() {
            IsSuccess = false,
            Errors = errors,
            Message = null
        };
    }
};

public record RegisterRequest(
    string Email,
    string FirstName,
    string LastName,
    string Password,
    string RoleId,
    int AffiliatedUnitId,
    int PositionId
);

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(req => req.Email).NotEmpty().EmailAddress();
        RuleFor(req => req.FirstName).NotEmpty();
        RuleFor(req => req.LastName).NotEmpty();
        RuleFor(req => req.Password).NotEmpty().Length(6,20);
        RuleFor(req => req.RoleId).NotEmpty();
        RuleFor(req => req.AffiliatedUnitId).NotEmpty();
        RuleFor(req => req.PositionId).NotEmpty();
    }
}
