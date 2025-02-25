namespace IPM.Application.UseCases.Auth.RegisterUseCase;

public class RegisterResponse {
    public bool IsSuccess {get; private set;}
    public string? Message {get; private set;}
    public Dictionary<string, string[]>? Errors {get; private set;}

    public static RegisterResponse Ok(string message)
    {
        return new RegisterResponse() {
            IsSuccess = true,
            Errors = null,
            Message = message
        };
    }

    public static RegisterResponse Error(Dictionary<string, string[]>? errors)
    {
        return new RegisterResponse() {
            IsSuccess = false,
            Errors = errors,
            Message = null
        };
    }
};
