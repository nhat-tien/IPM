namespace IPM.Infrastructure.Exceptions;

public class DbException: Exception
{
    public const string FOREIGN_KEY_VIOLATION = "23503";

    public DbException(string? message) : base(message)
    {
    }
}
