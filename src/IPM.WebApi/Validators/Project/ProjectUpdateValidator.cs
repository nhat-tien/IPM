using FluentValidation;
using IPM.Application.UseCases.Project.UpdateProjectUseCase;

namespace IPM.WebApi.Validators.Project;

public class ProjectUpdateValidator : AbstractValidator<UpdateProjectRequest>
{
    public ProjectUpdateValidator()
    {
    }
}
