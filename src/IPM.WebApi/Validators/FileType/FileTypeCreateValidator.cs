using FluentValidation;
using IPM.Application.UseCases.FileType.CreateFileTypeUseCase;

namespace IPM.WebApi.Validators.FileType;

public class FileTypeCreateValidator : AbstractValidator<CreateFileTypeRequest>
{
    public FileTypeCreateValidator()
    {
        RuleFor(e => e.FileTypeName).NotEmpty();
    }
}
