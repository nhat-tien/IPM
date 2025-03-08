
using IPM.Application.IRepositories;
using IPM.Application.Queries;

namespace IPM.Application.UseCases.User.GetCurrentUserUseCase;

public class GetCurrentUserHandler(IUserRepository repo): IGetCurrentUserUseCase
{
    public async Task<Domain.User?> Handle(string userId, CriteriaQuery query)
    {
        return await repo.GetById(userId, query);
    }
}
