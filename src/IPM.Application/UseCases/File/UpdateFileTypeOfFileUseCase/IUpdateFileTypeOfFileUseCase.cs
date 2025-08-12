namespace IPM.Application.UseCases.File.UpdateFileTypeOfFileUseCase;

public interface IUpdateFileTypeOfFileUseCase
{
    Task Handle(int id, UpdateFileTypeOfFileRequest req);
}
