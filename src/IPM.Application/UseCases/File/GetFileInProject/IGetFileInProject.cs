namespace IPM.Application.UseCases.File.GetFileInProject;

public interface IGetFileInProject
{
    Task<IEnumerable<Domain.File>> Handle(int projectId);
}
