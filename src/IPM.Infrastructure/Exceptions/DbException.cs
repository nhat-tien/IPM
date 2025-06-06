namespace IPM.Infrastructure.Exceptions;

public class DbException: Exception
{
    public string Type { get; set; } = "";
    public string Location { get; set; } = "";

    public const string FOREIGN_KEY_VIOLATION = "23503";

    public const string NOT_FOUND = "NOT_FOUND";

    public DbException(string? message) : base(message)
    {
    }

    public DbException(string type, string location, string? message) : base(message)
    {
        Type = type;
        Location = location;
    }
}
