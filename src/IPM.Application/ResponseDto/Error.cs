namespace IPM.Application.ResponseDto;

public class Error
{
    public string Code {get; private set;}
    public string Description {get; private set;}
    public ErrorType ErrorType {get; private set;}

    public Error(string code, int errorType, string description)
    {
        Code = code;
        ErrorType = (ErrorType) errorType;
        Description = description;
    }
}

public enum ErrorType {
    DATABASE = 0,
}
