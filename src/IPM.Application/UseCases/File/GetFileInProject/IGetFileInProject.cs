using IPM.Application.Queries;

namespace IPM.Application.UseCases.File.GetFileInProject;

public interface IGetFileInProject
{
    Task<IEnumerable<Domain.File>> Handle(int projectId, CriteriaQuery query);
}
