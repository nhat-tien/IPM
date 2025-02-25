using IPM.Application.Queries;
using IPM.Domain;

namespace IPM.Application.IRepositories;

public interface IProjectRepository: IResourceRepository<Project>
{
    new Task<Domain.Project> AddAsync(Domain.Project model);
    Task<IEnumerable<Domain.Project>> GetAllAsync(CriteriaQuery queryParam);
    Task<Domain.Project?> FindByIdAsync(int id, CriteriaQuery queryParam);
}
