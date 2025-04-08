using Npgsql;

namespace IPM.Infrastructure.Exceptions;

public class DbExceptionHandler
{
    public static void TryHandle(PostgresException e) 
    {
        switch(e.SqlState)
        {
            case DbException.FOREIGN_KEY_VIOLATION: 
                throw new DbException("FOREIGN_KEY_VIOLATION");
        }
    }
}
