namespace IPM.Application.UseCases.Auth.RefreshTokenUseCase;

  public interface IRefreshTokenUseCase
  {
    Task<RefreshTokenResponse> Handle(RefreshTokenRequest req);
  }
 
