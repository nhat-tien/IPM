using IPM.Application.IRepositories;
using IPM.Application.Queries;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using IPM.Infrastructure.EntityFrameworkDataAccess.Repositories.Common;
using Microsoft.EntityFrameworkCore;

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
        return db.Projects.Where(e => e.ProjectId == id);
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
        await db.Set<Project>().AddAsync(entity);
        await db.SaveChangesAsync();

        return entity.MapTo();
    }

    protected override IQueryable<Project> IncludeWith(IQueryable<Project> query, string[] includeList)
    {
        foreach (var item in includeList)
        {
            if(item.Equals("Participations"))
            {
                query = query.Include(e => e.Participations)!.ThenInclude(e => e.User);
            } else {
                query = query.Include(item);
            }
        }
        return query;
    }

    public override async Task<Domain.Project?> FindByIdAsync(int id, CriteriaQuery queryParam)
    {
        IQueryable<Project> query = WhereId(id);

        if(queryParam.Include is not null)
        {
            query = IncludeWith(query, queryParam.GetIncludeList);
        }

        Project? entity = await query.FirstOrDefaultAsync();

        if (entity is null)
        {
            return null;
        }

        return entity.MapTo();
    }

}
