using FluentValidation;
using IPM.Application.UseCases.Project.CreateProjectUseCase;

namespace IPM.WebApi.Validators.Project;

public class ProjectCreateValidator : AbstractValidator<CreateProjectRequest>
{
    public ProjectCreateValidator()
    {
        RuleFor(r => r.ProjectNameVietnamese).NotEmpty();
    }
}
