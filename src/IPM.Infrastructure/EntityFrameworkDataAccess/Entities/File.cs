namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

  public class File
  {
      public int FileId {get; set;}
      public int ProjectId { get; set; }
      public string? FileName { get; set; }
      public int FileTypeId { get; set; }
      public string? Url { get; set; }
      public DateTime CreatedAt { get; set; }
      public DateTime UpdatedAt { get; set; }
  }
 
