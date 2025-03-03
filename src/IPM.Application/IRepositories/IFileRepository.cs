using IPM.Application.Queries;

namespace IPM.Application.IRepositories;

public interface IFileRepository: IResourceRepository<Domain.File>
{
    Task<IEnumerable<Domain.File>> GetByProjectId(int id, CriteriaQuery query);
}
