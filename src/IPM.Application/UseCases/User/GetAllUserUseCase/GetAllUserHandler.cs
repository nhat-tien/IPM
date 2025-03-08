using IPM.Application.IRepositories;
using IPM.Application.Queries;

namespace IPM.Application.UseCases.User.GetAllUserUseCase;

public class GetAllUserHandler(IUserRepository repo): IGetAllUserUseCase
{
    public async Task<IEnumerable<Domain.User>> Handle(CriteriaQuery queryParam)
    {
        return await repo.GetAll(queryParam);
    }
}
