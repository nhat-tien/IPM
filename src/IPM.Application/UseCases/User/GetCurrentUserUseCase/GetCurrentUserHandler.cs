
using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.User.GetCurrentUserUseCase;

public class GetCurrentUserHandler(IUserRepository repo): IGetCurrentUserUseCase
{
    public async Task<Domain.User?> Handle(string userId)
    {
        return await repo.GetByIdIncludeRole(userId);
    }
}
