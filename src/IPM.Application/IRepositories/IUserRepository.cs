using IPM.Domain;

namespace IPM.Application.IRepositories;

public interface IUserRepository
{
    Task<User?> GetById(string id);
}
 
