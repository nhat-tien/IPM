namespace IPM.Domain;

  public class Project
  {
    public int ProjectId { get; set; }
    public int AffilatedUnitId { get; set; }
    public int CatalogueId { get; set; }
    public int SponsorId { get; set; }
    public int AidType { get; set; }
    public int ApprovingAgency { get; set; }
    public int Counterparty { get; set; }
    public string? ProjectNameEnglish { get; set; }
    public string? ProjectNameVietnamese { get; set; }
    public string? ProjectPurpose { get; set; }
    public string? Content { get; set; }
  }
 
