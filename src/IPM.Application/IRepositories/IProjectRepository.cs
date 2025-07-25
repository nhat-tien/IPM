using IPM.Application.Queries;
using IPM.Application.ResponseDto;
using IPM.Domain;

namespace IPM.Application.IRepositories;

public interface IProjectRepository: IGenericRepository<Project>
{
    new Task<Domain.Project> AddAsync(Domain.Project model);
    Task<IEnumerable<Domain.Project>> GetAllAsync(CriteriaQuery queryParam);
    Task<PaginationResponse<Domain.Project>> GetAllWithPaginationAsync(CriteriaQuery queryParam);
    Task<Domain.Project?> FindByIdAsync(int id, CriteriaQuery queryParam);
    Task UpdateAsync(Domain.Project model, List<string> setValueProperties);
    Task DeleteSoftByIdAsync(int id);
}
