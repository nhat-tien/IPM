namespace IPM.Application.IRepositories; 

public interface IGenericRepository<T> where T: class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> FindByIdAsync(int id);
    Task AddAsync(T model);
    Task DeleteByIdAsync(int id);
    Task UpdateAsync(T model);
}
