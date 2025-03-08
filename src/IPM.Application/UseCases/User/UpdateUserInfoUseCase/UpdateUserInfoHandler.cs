
using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.User.UpdateUserInfoUseCase;

public class UpdateUserInfoHandler(IUserRepository repo): IUpdateUserInfoUseCase
{
    public async Task Handle(string userId, UpdateUserInfoRequest req)
    {
        Domain.User domain = req.MapTo();
        domain.UserId = userId;
        await repo.UpdateAsync(domain);
    }
}
