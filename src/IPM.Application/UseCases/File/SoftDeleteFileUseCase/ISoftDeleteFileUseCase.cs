namespace IPM.Application.UseCases.File.SoftDeleteFileUseCase;

public interface ISoftDeleteFileUseCase
{
    Task Handle(int fileId);
}
