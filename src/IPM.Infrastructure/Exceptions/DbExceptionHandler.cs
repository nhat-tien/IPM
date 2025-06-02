using Npgsql;

namespace IPM.Infrastructure.Exceptions;

public class DbExceptionHandler
{
    public static void TryHandle(PostgresException e, string locationOccurred) 
    {
        switch(e.SqlState)
        {
            case DbException.FOREIGN_KEY_VIOLATION:
                throw new DbException(
                    nameof(DbException.FOREIGN_KEY_VIOLATION), 
                    locationOccurred,
                    "Lỗi vi phạm khóa ngoại"
                );
        }
    }
}
