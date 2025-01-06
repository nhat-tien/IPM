using IPM.Application.IRepositories;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class ApprovingAgencyRepository : IApprovingAgencyRepository
{
    public Task<int> Create(Domain.ApprovingAgency model)
    {
        throw new NotImplementedException();
    }

    public Task<int> Delete(Domain.ApprovingAgency model)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.ApprovingAgency?> FindById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Domain.ApprovingAgency>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<int> Update(Domain.ApprovingAgency model)
    {
        throw new NotImplementedException();
    }
}
