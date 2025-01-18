namespace IPM.Application.UseCases.Category.GetAllCategoryUseCase;

public interface IGetAllCategoryUseCase
{
    Task<IEnumerable<Domain.Category>> Handle();
}
