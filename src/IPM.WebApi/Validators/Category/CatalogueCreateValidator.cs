using FluentValidation;
using IPM.Application.UseCases.Category.CreateCategoryUseCase;

namespace IPM.WebApi.Validators.Category;

public class CategoryCreateValidator : AbstractValidator<CreateCategoryRequest>
{
    public CategoryCreateValidator()
    {
        RuleFor(req => req.CategoryName).NotEmpty();
    }
}
