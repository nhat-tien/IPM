namespace IPM.Application.ResponseDto;

public class PaginationResponse<T> where T : class
{
    public PaginationResponseMetadata? Metadata {get; set;}
    public IEnumerable<T>? Data {get; set;}
}

public class PaginationResponseMetadata {
    public int TotalCount {get; set;}
    public int PageCount {get; set;}
    public int Page {get; set;}
    public int PageSize {get; set;}
}

