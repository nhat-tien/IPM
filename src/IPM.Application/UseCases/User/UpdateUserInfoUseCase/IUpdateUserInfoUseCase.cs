namespace IPM.Application.UseCases.User.UpdateUserInfoUseCase;

public interface IUpdateUserInfoUseCase
{
    Task Handle(string userId, UpdateUserInfoRequest req);
}
