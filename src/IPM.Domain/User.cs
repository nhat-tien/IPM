namespace IPM.Domain;

public class User
{
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int PositionId { get; set; }
    public int AffilatedUnitId { get; set; }
    public int RoleId { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public int Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Role? Role {get; set;}

    //NOTE: I'm not sure about this property's type, maybe it's a string
    public int VerifiedCodeEmail { get; set; }

    public int VerifiedStatus { get; set; }
    public DateTime VerificationValidTime { get; set; }

    // public User(
    //     string userId,
    //     string firstName,
    //     string lastName,
    //     int positionId,
    //     int affilatedUnitId,
    //     int roleId,
    //     string phoneNumber,
    //     string address,
    //     string email,
    //     int status,
    //     DateTime createdAt,
    //     DateTime updatedAt,
    //     int verifiedCodeEmail,
    //     int verifiedStatus,
    //     DateTime verificationValidTime
    // )
    // {
    //     UserId = userId;
    //     FirstName = firstName;
    //     LastName = lastName;
    //     PositionId = positionId;
    //     AffilatedUnitId = affilatedUnitId;
    //     RoleId = roleId;
    //     PhoneNumber = phoneNumber;
    //     Address = address;
    //     Email = email;
    //     Status = status;
    //     CreatedAt = createdAt;
    //     UpdatedAt = updatedAt;
    //     VerifiedCodeEmail = verifiedCodeEmail;
    //     VerifiedStatus = verifiedStatus;
    //     VerificationValidTime = verificationValidTime;
    // }

}
