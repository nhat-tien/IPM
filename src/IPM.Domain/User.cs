namespace IPM.Domain;

public class User
{
    public int UserId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int PositionId { get; private set; }
    public int AffilatedUnitId { get; private set; }
    public int RoleId { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Address { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public int Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    //NOTE: I'm not sure about this property's type, maybe it's a string
    public int VerifiedCodeEmail { get; set; }

    public int VerifiedStatus { get; set; }
    public DateTime VerificationValidTime { get; set; }

    public User(
        int userId,
        string firstName,
        string lastName,
        int positionId,
        int affilatedUnitId,
        int roleId,
        string phoneNumber,
        string address,
        string email,
        string password,
        int status,
        DateTime createdAt,
        DateTime updatedAt,
        int verifiedCodeEmail,
        int verifiedStatus,
        DateTime verificationValidTime
    )
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        PositionId = positionId;
        AffilatedUnitId = affilatedUnitId;
        RoleId = roleId;
        PhoneNumber = phoneNumber;
        Address = address;
        Email = email;
        Password = password;
        Status = status;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        VerifiedCodeEmail = verifiedCodeEmail;
        VerifiedStatus = verifiedStatus;
        VerificationValidTime = verificationValidTime;
    }
}
