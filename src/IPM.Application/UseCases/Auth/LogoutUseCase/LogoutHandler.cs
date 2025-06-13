
using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Auth.LogoutUseCase;

public class LogoutHandler(
    IRefreshTokenRepository refreshTokenRepo
): ILogoutUseCase
{
    public async Task Handle(string refreshToken)
    {
        await refreshTokenRepo.Delete(refreshToken);
    }
}
