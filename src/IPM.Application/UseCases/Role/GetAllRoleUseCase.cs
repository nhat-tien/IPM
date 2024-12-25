using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Role;

public class GetAllRoleUseCase: IGetAllRoleUseCase
{
    private IRoleRepository roleRepo;

    public GetAllRoleUseCase(IRoleRepository roleRepo)
    {
        this.roleRepo = roleRepo;
    }

    public async Task<List<Domain.Role>> Execute()
    {
        return await this.roleRepo.GetAll();
    }
}
 
