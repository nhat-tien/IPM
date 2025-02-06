using IPM.Domain;

namespace IPM.Application.IRepositories;

public interface IUserRepository
{
    Task<User?> GetById(string id);
    Task<User?> FindByName(string name);
    Task<bool> CheckPassword(User user, string password);
    Task<IList<string>> GetRoles(User user);
    Task<CreateResult> Create(User domainUser, string password);
    Task AddToRole(User user, string roleName);
    Task<IEnumerable<User>> GetAll();
    Task<IEnumerable<User>> GetAllWithRole();
}

public class CreateResult {
    public bool IsSucceeded {get; set;}
    public string? Message {get; set;}
    public Dictionary<string, string[]>? Errors {get; set;}

    public static CreateResult Ok(string message)
    {
        return new CreateResult()
        {
            IsSucceeded = true,
            Message = message,
            Errors = null
        };
    }

    public static CreateResult Error(Dictionary<string, string[]> error)
    {
        return new CreateResult()
        {
            IsSucceeded = false,
            Message = null,
            Errors = error
        };
    }
}
 
