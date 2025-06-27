using System.Text.RegularExpressions;

namespace IPM.Application.Queries;

public class CriteriaQuery 
{
    public string? SortColumn {get; set;}
    public string? SortOrder {get; set;}
    public string? Include {get; set;}
    public int? Page {get; set;}
    public bool? PageMetadata {get; set;}
    public int? PageSize {get; set;}
    public string? Filter {get;set;}

    public string[] GetIncludeList => Include is not null ? Include.Split(",") : [];

    public List<FilterItem> GetFilterList() {
        if(Filter is null) return [];
        string pattern = @"^(\w+)\[(.=?)\](.+)$";

        return Filter.Split(",").Select(e => {
            Match match = Regex.Match(e, pattern);
            return new FilterItem(
                match.Groups[1].Value,
                match.Groups[2].Value,
                match.Groups[3].Value
            );
        }).ToList();
    }
}

