namespace IPM.Application.UseCases.Auth.RefreshTokenUseCase;

public class RefreshTokenResponse {
    public bool IsSuccess {get; private set;}
    public string? Message {get; private set;}
    public string? AccessToken {get; private set;}
    public string? RefreshToken {get; private set;}

    public static RefreshTokenResponse Ok(string message, string accessToken, string refreshToken)
    {
        return new RefreshTokenResponse() {
            IsSuccess = true,
            Message = message,
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    public static RefreshTokenResponse Error(string errors)
    {
        return new RefreshTokenResponse() {
            IsSuccess = false,
            Message = errors,
            AccessToken = null,
            RefreshToken = null 
        };
    }
};
 
