namespace IPM.Application.IRepositories;

  public interface IRepository<T> where T: class
  {
      public Task<T> GetById(int id);
  }
 
