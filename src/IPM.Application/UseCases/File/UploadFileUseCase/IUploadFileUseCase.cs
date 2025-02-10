using IPM.Application.IUtils;

namespace IPM.Application.UseCases.File.UploadFileUseCase;

public interface IUploadFileUseCase
{
    Task Handle(IFile file, string fileTypeId, string projectId);
}
