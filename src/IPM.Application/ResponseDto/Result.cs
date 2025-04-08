namespace IPM.Application.ResponseDto;

public class Result
{
    public bool IsSuccess {get; private set;}
    public Error? Error {get; private set;}

    public static Result Success() => new(true, null);

    public static Result Fail(Error err) => new(false, err);

    public Result(bool isSuccess, Error? err)
    {
        IsSuccess = isSuccess;
        Error = err;
    }
}
