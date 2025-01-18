using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Category.DeleteCategoryUseCase;

public class DeleteCategoryHandler(ICategoryRepository repo): IDeleteCategoryUseCase
{
    public async Task Handle(int id)
    {
        await repo.Delete(id);
    }
}
