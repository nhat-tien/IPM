using IPM.Domain;

namespace IPM.Application.IRepositories;

public interface IProjectRepository: IResourceRepository<Project>
{
    new Task<Domain.Project> AddAsync(Domain.Project model);
}
