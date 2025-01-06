namespace IPM.Application.IRepositories; 

public interface IResourceRepository<T> where T: class
{
    Task<List<T>> GetAll();
    Task<T?> FindById(int id);
    Task<int> Create(T model);
    Task<int> Delete(T model);
    Task<int> Update(T model);
}
