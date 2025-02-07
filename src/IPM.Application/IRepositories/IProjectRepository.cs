using IPM.Domain;

namespace IPM.Application.IRepositories;

public interface IProjectRepository: IResourceRepository<Project>
{
    public new Task<Domain.Project> AddAsync(Domain.Project model);
}
