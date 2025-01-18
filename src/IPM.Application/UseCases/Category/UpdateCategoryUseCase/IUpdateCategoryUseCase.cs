namespace IPM.Application.UseCases.Category.UpdateCategoryUseCase;

public interface IUpdateCategoryUseCase
{
    Task Handle(int id, UpdateCategoryRequest req);
}
