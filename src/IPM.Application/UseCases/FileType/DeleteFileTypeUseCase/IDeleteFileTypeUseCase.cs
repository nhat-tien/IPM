namespace IPM.Application.UseCases.FileType.DeleteFileTypeUseCase;

public interface IDeleteFileTypeUseCase
{
    Task Handle(int id);
}
