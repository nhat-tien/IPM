namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

  public class FileType
  {
      public int FileTypeId { get; set; }
      public string? FileTypeName { get; set; }
      public DateTime CreatedAt { get; set; }
      public DateTime UpdatedAt { get; set; }
  }
 
