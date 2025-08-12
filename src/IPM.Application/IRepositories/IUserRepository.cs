using IPM.Application.Queries;
using IPM.Domain;

namespace IPM.Application.IRepositories;

public interface IUserRepository
{
    Task<User?> GetById(string id);
    Task<User?> GetById(string id, CriteriaQuery queryParam);
    Task<User?> FindByName(string name);
    Task<IEnumerable<User>> GetAll();
    Task<IEnumerable<User>> GetAll(CriteriaQuery queryParam);
    Task<IList<string>> GetRoles(User user);

    Task<bool> CheckPassword(User user, string password);
    Task<CreateResult> CreateAsync(User domainUser, string password);
    Task AddToRole(User user, string roleName);
    Task AddAvaterUrl(string userId, string url);

    Task UpdateAsync(User model);
}

public class CreateResult {
    public bool IsSucceeded {get; set;}
    public string? Message {get; set;}
    public string? Errors {get; set;}

    public static CreateResult Ok(string message)
    {
        return new CreateResult()
        {
            IsSucceeded = true,
            Message = message,
            Errors = null
        };
    }

    public static CreateResult Error(string error)
    {
        return new CreateResult()
        {
            IsSucceeded = false,
            Message = null,
            Errors = error
        };
    }
}
 
