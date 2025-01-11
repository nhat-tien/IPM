namespace IPM.Infrastructure.EntityFrameworkDataAccess;

public class NpgsqlConnectStringBuilder
{
    public required string Database {get; set;}
    public required string Host {get; set;}
    public required string User  {get; set;}
    public required string Password {get; set;}
    public required string Port {get; set;}
    public string ConnectionString
    {
        get { return $"Server={Host};Port={Port};Userid={User};Password={Password};Database={Database}" ; }
    }
}
