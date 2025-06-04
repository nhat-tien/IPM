namespace IPM.Application.ResponseDto;

public record UserInfo
(
  string UserId,
  string Email,
  string FirstName,
  string LastName,
  string Role
);
