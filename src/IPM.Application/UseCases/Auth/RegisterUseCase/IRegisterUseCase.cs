namespace IPM.Application.UseCases.Auth.RegisterUseCase;

public interface IRegisterUseCase 
{
    RegisterResponse Execute(RegisterRequest req);
}
