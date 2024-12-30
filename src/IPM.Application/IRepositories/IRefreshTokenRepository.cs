using IPM.Domain;

namespace IPM.Application.IRepositories;

public interface IRefreshTokenRepository
{
    Task Add(Domain.RefreshToken refreshToken);
    Task<RefreshToken?> FindByTokenIncludeUser(string refreshToken);
    Task Update(string oldToken, string newToken);
}
