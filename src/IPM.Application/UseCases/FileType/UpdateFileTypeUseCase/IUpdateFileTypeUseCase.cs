namespace IPM.Application.UseCases.FileType.UpdateFileTypeUseCase;

public interface IUpdateFileTypeUseCase
{
    Task Handle(int id, UpdateFileTypeRequest req);
}
