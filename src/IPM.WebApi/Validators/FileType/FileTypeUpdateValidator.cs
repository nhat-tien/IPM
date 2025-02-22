using FluentValidation;
using IPM.Application.UseCases.FileType.UpdateFileTypeUseCase;

namespace IPM.WebApi.Validators.FileType;

public class FileTypeUpdateValidator : AbstractValidator<UpdateFileTypeRequest>
{
    public FileTypeUpdateValidator()
    {
        RuleFor(e => e.FileTypeName).NotEmpty();
    }
}
