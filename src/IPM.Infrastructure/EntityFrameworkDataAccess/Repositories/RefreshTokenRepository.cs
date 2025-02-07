using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class RefreshTokenRepository(AppDBContext db) : IRefreshTokenRepository
{
    public async Task Add(Domain.RefreshToken refreshToken)
    {
        db.RefreshTokens.Add(RefreshToken.MapFrom(refreshToken));
        await db.SaveChangesAsync();
    }

    public async Task<Domain.RefreshToken?> FindByTokenIncludeUser(string token)
    {
        RefreshToken? refreshToken = await db.RefreshTokens
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
        RefreshToken? refreshToken = await db.RefreshTokens.FirstOrDefaultAsync(r => r.Token == oldToken);
        if(refreshToken is not null) {
            refreshToken.Token = newToken;
        }
        await db.SaveChangesAsync();
    }
}
