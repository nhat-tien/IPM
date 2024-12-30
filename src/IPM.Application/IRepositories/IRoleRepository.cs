using IPM.Domain;

namespace IPM.Application.IRepositories;

public interface IRoleRepository
{
    Task<List<Role>> GetAll();
    Task<Role?> FindById(string roleId);
}
