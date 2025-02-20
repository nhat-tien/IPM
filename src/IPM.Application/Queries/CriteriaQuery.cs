namespace IPM.Application.Queries;

public class CriteriaQuery 
{
    public string? SortColumn {get; set;}
    public string? SortOrder {get; set;}
    public string? Include {get; set;}
    public int? Page {get; set;}
    public int? PageSize {get; set;}

    public string[] GetIncludeList => Include is not null ? Include.Split(",") : [];

    
}
