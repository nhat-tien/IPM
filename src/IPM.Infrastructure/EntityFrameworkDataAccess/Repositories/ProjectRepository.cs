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

    public override async Task<Domain.Project> AddAsync(Domain.Project domain) 
    {
        Project entity = MapFromDomain(domain);
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        await context.Set<Project>().AddAsync(entity);
        await context.SaveChangesAsync();

        return entity.MapTo();
    }
}
