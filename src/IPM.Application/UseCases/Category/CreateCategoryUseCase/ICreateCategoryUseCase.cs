namespace IPM.Application.UseCases.Category.CreateCategoryUseCase;

public interface ICreateCategoryUseCase
{
    Task Handle(CreateCategoryRequest req);
}
