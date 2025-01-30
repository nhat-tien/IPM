using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Category.UpdateCategoryUseCase;

public class UpdateCategoryHandler(ICategoryRepository repo) : IUpdateCategoryUseCase
{
    public async Task Handle(int id, UpdateCategoryRequest req)
    {
        Domain.Category entity = new Domain.Category() {
            CategoryId = id,
            CategoryName = req.CategoryName
        };
        await repo.UpdateAsync(entity);
    }
}
