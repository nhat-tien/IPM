namespace IPM.Application.IRepositories;

using IPM.Domain;

public interface IUserRepository
{
    public User? GetUserByEmail(string email);
}
