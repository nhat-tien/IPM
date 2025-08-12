
using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.User.VerifyUserUseCase;

public class VerifyUserHandler(IUserRepository userRepo): IVerifyUserUseCase
{
    public async Task Handle(string userId)
    {
        Domain.User user = new Domain.User() {
            UserId = userId,
            IsVerified = true
        };

        await userRepo.UpdateAsync(user);
    }
}
