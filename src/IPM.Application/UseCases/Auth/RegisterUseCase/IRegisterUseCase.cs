namespace IPM.Application.UseCases.Auth.RegisterUseCase;

public interface IRegisterUseCase 
{
    Task<RegisterResponse> Handle(RegisterRequest req);
}
