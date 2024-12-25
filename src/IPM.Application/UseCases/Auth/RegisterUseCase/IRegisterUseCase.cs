namespace IPM.Application.UseCases.Auth.RegisterUseCase;

public interface IRegisterUseCase 
{
    Task<RegisterResponse> Execute(RegisterRequest req);
}
