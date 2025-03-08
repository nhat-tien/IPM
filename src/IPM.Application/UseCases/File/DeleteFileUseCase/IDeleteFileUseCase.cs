namespace IPM.Application.UseCases.File.DeleteFileUseCase;

public interface IDeleteFileUseCase
{
    Task Handle(int fileId);
}
