namespace IPM.Application.IRepositories; 

public interface IResourceRepository<T> where T: class
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> FindById(int id);
    Task Create(T model);
    Task Delete(int id);
    Task Update(int id, T model);
}
