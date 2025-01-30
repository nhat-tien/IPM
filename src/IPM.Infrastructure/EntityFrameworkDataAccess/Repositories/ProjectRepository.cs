using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using IPM.Infrastructure.EntityFrameworkDataAccess.Repositories.Common;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class ProjectRepository : GenericRepository<Domain.Project, Project>, IProjectRepository
{
    public ProjectRepository(AppDBContext ctx) : base(ctx)
    {
    }

    public override int GetDomainId(Domain.Project domain)
    {
        return domain.ProjectId;
    }

    public override IQueryable<Project> WhereId(int id)
    {
        return context.Projects.Where(e => e.ProjectId == id);
    }

    public override Project MapFromDomain(Domain.Project domain)
    {
        return Project.MapFrom(domain);
    }

    public override Domain.Project MapToDomain(Project entity)
    {
        return entity.MapTo();
    }
}
