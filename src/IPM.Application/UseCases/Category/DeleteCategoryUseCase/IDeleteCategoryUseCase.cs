namespace IPM.Application.UseCases.Category.DeleteCategoryUseCase;

public interface IDeleteCategoryUseCase
{
    Task Handle(int id);
}
