namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

using System.Threading.Tasks;
using IPM.Domain;

public class UserRepository 
{
    private AppDBContext _ctx;

    public UserRepository(AppDBContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<User> GetById(int id)
    {
        var user = await _ctx.Users.FindAsync(id);
        if(user == null) {
            return new User();
        }
        return User.LoadFromDetail(user.UserId, user.FirstName);
    }
}
