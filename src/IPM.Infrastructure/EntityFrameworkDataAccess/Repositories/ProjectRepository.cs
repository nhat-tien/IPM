using System.Reflection;
using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class ProjectRepository(AppDBContext context): IProjectRepository
{
    public async Task Create(Domain.Project model)
    {
        var entity = Project.MapFrom(model);
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        await context.Projects.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        await context.Projects.Where(e => e.ProjectId == id).ExecuteDeleteAsync();
    }

    public async Task<Domain.Project?> FindById(int id)
    {
        Project? entity = await context.Projects.FindAsync(id);
        if(entity is null) 
        {
            return null;
        }
        return entity.MapTo();
    }

    public async Task<IEnumerable<Domain.Project>> GetAll()
    {
        List<Project> entity = await context.Projects.ToListAsync();
        IEnumerable<Domain.Project> listOfDomain = entity.Select(entity => entity.MapTo());
        return listOfDomain;
    }

    public async Task Update(Domain.Project model)
    {
        Project? entity = await context.Projects.FirstOrDefaultAsync(e => e.ProjectId == model.ProjectId);
        if(entity is null) return;
        context.Projects.Attach(entity);

        Type typeOfModel = model.GetType();
        PropertyInfo[] properties = typeOfModel.GetProperties();
        foreach(PropertyInfo property in properties) 
        {
            if(property.GetValue(model) is not null) 
            {
                context.Entry(entity).Property(property.Name).CurrentValue = property.GetValue(model); 
            }
        }
        await context.SaveChangesAsync();
    }
}
