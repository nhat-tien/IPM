using IPM.Application.IRepositories;
namespace IPM.Application.UseCases.User.GetAllUserUseCase;

public class GetAllUserHandler(IUserRepository repo): IGetAllUserUseCase
{
    public async Task<IEnumerable<Domain.User>> Handle()
    {
        return await repo.GetAllWithRole();
    }
}
