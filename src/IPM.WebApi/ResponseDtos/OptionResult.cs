namespace IPM.WebApi.ResponseDtos;

public class OptionResult<T>
{
    private T? _data;

    public OptionResult(T? result)
    {
        _data = result;
    }

    public IResult GetResult()
    {
        if(_data is not null)
        {
            return TypedResults.Ok(_data);
        }

        return TypedResults.NotFound();
    }
}
