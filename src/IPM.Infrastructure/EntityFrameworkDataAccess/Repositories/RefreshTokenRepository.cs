using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class RefreshTokenRepository(IAppDBContext context) : IRefreshTokenRepository
{
    public async Task Add(Domain.RefreshToken refreshToken)
    {
        context.RefreshTokens.Add(RefreshToken.MapFrom(refreshToken));
        await context.SaveChangesAsync();
    }

    public async Task<Domain.RefreshToken?> FindByTokenIncludeUser(string token)
    {
        RefreshToken? refreshToken = await context.RefreshTokens
            .Include(r => r.User)
            .FirstOrDefaultAsync(r => r.Token == token);
        if(refreshToken is null)
        {
            return null;
        }
        return refreshToken.MapTo();
    }

    public async Task Update(string oldToken, string newToken)
    {
        RefreshToken? refreshToken = await context.RefreshTokens.FirstOrDefaultAsync(r => r.Token == oldToken);
        if(refreshToken is not null) {
            refreshToken.Token = newToken;
        }
        await context.SaveChangesAsync();
    }
}
