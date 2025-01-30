using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Category.CreateCategoryUseCase;

public class CreateCategoryHandler(ICategoryRepository repo): ICreateCategoryUseCase
{
    public async Task Handle(CreateCategoryRequest req)
    {
        Domain.Category entity = new Domain.Category() {
            CategoryName = req.CategoryName
        };
        await repo.AddAsync(entity);
    }
}
