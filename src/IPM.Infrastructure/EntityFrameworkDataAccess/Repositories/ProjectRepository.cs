using System.Reflection;
using IPM.Application.IRepositories;
using IPM.Application.Queries;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using IPM.Infrastructure.EntityFrameworkDataAccess.Repositories.Common;
using IPM.Infrastructure.Exceptions;
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

    public override async Task<IEnumerable<Domain.Project>> GetAllAsync(CriteriaQuery queryParam)
    {
        if(queryParam.SortColumn is not null) 
        {
            IEnumerable<Domain.Project> listOfDomain;
            switch(queryParam.SortColumn)
            {
                case "CreatedAt":
                    listOfDomain = await GetAllAsync(queryParam, (e) => e.CreatedAt);
                    break;
                default:
                    listOfDomain = await GetAllAsync(queryParam, (e) => e.ProjectId);
                    break;
            }
            return listOfDomain;
        } else {
            IEnumerable<Domain.Project> listOfDomain = await GetAllAsync(queryParam, (e) => e.ProjectId);
            return listOfDomain;
        }
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

    public async Task DeleteSoftByIdAsync(int id) 
    {
        Domain.Project? project = await this.FindByIdAsync(id);

        if(project is null) {
            throw new DbException(DbException.NOT_FOUND, "ProjectRepository", "Not found entity");
        }

        project.IsDeleted = true; 

        await this.UpdateAsync(project);
    }

    public async Task UpdateAsync(Domain.Project model, List<string> setValueProperties)
    {
        var domainId = GetDomainId(model);
        Project? entity = await WhereId(domainId).FirstOrDefaultAsync();
        if (entity is null)
            return;
        db.Set<Project>().Attach(entity);

        Type typeOfModel = model.GetType();
        PropertyInfo[] properties = typeOfModel.GetProperties();
        foreach (PropertyInfo property in properties)
        {
            if (property.Name == "CreatedAt")
            {
                continue;
            }
            if (property.GetValue(model) is not null || setValueProperties.Contains(property.Name))
            {
                db.Entry(entity).Property(property.Name).CurrentValue = property.GetValue(model);
            }
        }
        entity.UpdatedAt = DateTime.UtcNow;
        await db.SaveChangesAsync();
    }
}
