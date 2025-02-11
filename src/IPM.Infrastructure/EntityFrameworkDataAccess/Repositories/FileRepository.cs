using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Repositories.Common;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class FileRepository : GenericRepository<Domain.File, Entities.File>, IFileRepository
{
    public FileRepository(AppDBContext ctx) : base(ctx)
    {
    }

    public override int GetDomainId(Domain.File domain)
    {
        return domain.FileId;
    }

    public override Entities.File MapFromDomain(Domain.File domain)
    {
        return Entities.File.MapFrom(domain);
    }

    public override Domain.File MapToDomain(Entities.File entity)
    {
        return entity.MapTo();
    }

    public override IQueryable<Entities.File> WhereId(int id)
    {
        return db.Files.Where(e => e.FileId == id);
    }

    public override async Task AddAsync(Domain.File domain) 
    {
        Entities.File entity = MapFromDomain(domain);
        entity.ObjectName = $"{domain.ProjectId}_{DateTime.UtcNow.ToString()}_{domain.FileName}";
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        await db.Set<Entities.File>().AddAsync(entity);
        await db.SaveChangesAsync();
    }
}
