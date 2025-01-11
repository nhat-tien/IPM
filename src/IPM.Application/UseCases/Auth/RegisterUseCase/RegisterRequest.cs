namespace IPM.Application.UseCases.Auth.RegisterUseCase;

public record RegisterRequest(
    string Email,
    string FirstName,
    string LastName,
    string Password,
    string RoleId
    // int AffiliatedUnitId,
    // int PositionId
);
