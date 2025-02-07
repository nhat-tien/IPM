namespace IPM.Application.UseCases.FileType.GetAllFileTypeUseCase;

public interface IGetAllFileTypeUseCase
{
    Task<IEnumerable<Domain.FileType>> Handle();
}
