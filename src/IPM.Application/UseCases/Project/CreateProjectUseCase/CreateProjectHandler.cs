using IPM.Application.IUnitOfWorks;

namespace IPM.Application.UseCases.Project.CreateProjectUseCase;

public class CreateProjectHandler(IProjectUnitOfWork uow): ICreateProjectUseCase
{
    public async Task<Domain.Project> Handle(CreateProjectRequest req, string userId)
    {
        return await uow.AddProjectAndAssignOwnerAsync(req.MapTo(), userId);
    }
}
