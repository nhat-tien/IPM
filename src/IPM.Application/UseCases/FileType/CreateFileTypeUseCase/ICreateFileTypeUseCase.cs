namespace IPM.Application.UseCases.FileType.CreateFileTypeUseCase;

public interface ICreateFileTypeUseCase
{
Task Handle(CreateFileTypeRequest req);
}
