using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Category.GetAllCategoryUseCase;

public class GetAllCategoryHandler(ICategoryRepository repo) : IGetAllCategoryUseCase
{
    public async Task<IEnumerable<Domain.Category>> Handle()
    {
        return await repo.GetAll();
    }
}
