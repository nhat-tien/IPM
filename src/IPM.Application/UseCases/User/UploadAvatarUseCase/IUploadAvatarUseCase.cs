using IPM.Application.IUtils;

namespace IPM.Application.UseCases.User.UploadAvatarUseCase;

public interface IUploadAvatarUseCase
{
    Task Handle(IFile avatar, string userId);
}
