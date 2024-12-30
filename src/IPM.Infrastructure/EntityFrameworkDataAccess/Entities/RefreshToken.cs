namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class RefreshToken
{
    public Guid Id { get; set; }
    public string Token { get; set; } = ""!;
    public string UserId { get; set; } = ""!;
    public DateTime ExpiresOnUtc { get; set; }
    public User? User { get; set; }

    public Domain.RefreshToken MapTo() 
    {
        return new Domain.RefreshToken() 
        {
            Id = Id,
            Token = Token,
            UserId = UserId,
            ExpiresOnUtc = ExpiresOnUtc,
            User = User?.MapTo()
        };
    }

    public static RefreshToken MapFrom(Domain.RefreshToken refreshToken)
    {
        return new RefreshToken() 
        {
            Id = refreshToken.Id,
            Token = refreshToken.Token,
            UserId = refreshToken.UserId,
            ExpiresOnUtc = refreshToken.ExpiresOnUtc,
            //WARNING: Code suck
            User = refreshToken.User is null ? null : User.MapFrom(refreshToken.User)
        };
    }
}
