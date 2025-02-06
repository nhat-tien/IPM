using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using IPM.Infrastructure.EntityFrameworkDataAccess.Repositories.Common;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class FileTypeRepository : GenericRepository<Domain.FileType, FileType>, IFileTypeRepository
{
    public FileTypeRepository(AppDBContext ctx) : base(ctx)
    {
    }

    public override int GetDomainId(Domain.FileType domain)
    {
        return domain.FileTypeId;
    }

    public override FileType MapFromDomain(Domain.FileType domain)
    {
        return FileType.MapFrom(domain);
    }

    public override Domain.FileType MapToDomain(FileType entity)
    {
        return entity.MapTo();
    }

    public override IQueryable<FileType> WhereId(int id)
    {
        return context.FileTypes.Where(e => e.FileTypeId == id);
    }
}
