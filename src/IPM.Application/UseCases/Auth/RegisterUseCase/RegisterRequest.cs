using FluentValidation;

namespace IPM.Application.UseCases.Auth.RegisterUseCase;

public class RegisterRequest
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string RoleId { get; set; }
    public int AffiliatedUnitId {get; set;}
    public int PositionId { get; set; }
}

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
