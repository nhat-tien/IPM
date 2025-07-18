
using IPM.Application.IRepositories;
using IPM.Application.Queries;

namespace IPM.Application.UseCases.File.GetFileInProject;

public class GetFileInProjectHandler(IFileRepository repo): IGetFileInProject
{
    public Task<IEnumerable<Domain.File>> Handle(int projectId, CriteriaQuery query)
    {
        return repo.GetByProjectId(projectId, query);
    }
}
