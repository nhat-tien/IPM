namespace IPM.Application.IUnitOfWorks;

public interface IProjectUnitOfWork
{
    Task<Domain.Project> AddProjectAndAssignOwnerAsync(Domain.Project model, string userId);
}
