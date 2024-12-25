namespace IPM.Application.UseCases.Role
{
    public interface IGetAllRoleUseCase
    {
       Task<List<Domain.Role>> Execute();
    }
}
