using IPM.Domain;

namespace IPM.Application.IServices;

public interface IAuthService
{
    string CreateAccessToken(User user, string role);
    string GenerateRefreshToken();
}

