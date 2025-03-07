using IPM.Application.IUnitOfWorks;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.UnitOfWorks;

public class ProjectUnitOfWork(AppDBContext db): IProjectUnitOfWork
{
    public async Task<Domain.Project> AddProjectAndAssignOwnerAsync(Domain.Project model, string userId)
    {
        Project entity = Project.MapFrom(model);
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        await db.Projects.AddAsync(entity);

        Participation participation = new Participation() {
            ProjectId = entity.ProjectId,
            UserId = userId,
            Owner = true
        };
        await db.Participations.AddAsync(participation);

        await db.SaveChangesAsync();

        return entity.MapTo();
    }
}
