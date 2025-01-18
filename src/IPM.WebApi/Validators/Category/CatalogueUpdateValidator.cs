using FluentValidation;
using IPM.Application.UseCases.Category.UpdateCategoryUseCase;

namespace IPM.WebApi.Validators.Category;

public class CategoryUpdateValidator : AbstractValidator<UpdateCategoryRequest>
{
    public CategoryUpdateValidator()
    {
        RuleFor(req => req.CategoryName).NotEmpty();
    }
}
