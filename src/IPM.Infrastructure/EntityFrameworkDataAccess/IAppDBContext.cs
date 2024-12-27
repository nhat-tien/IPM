namespace IPM.Infrastructure.EntityFrameworkDataAccess;

using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

public interface IAppDBContext
{
    // DbSet<User> Users {get; set;}
    DbSet<AffiliatedUnit> AffiliatedUnits {get;set;}
    DbSet<AidType> AidTypes {get;set;}
    DbSet<ApprovingAgency> ApprovingAgencies {get;set;}
    DbSet<AttachedFile> AttachedFiles {get;set;}
    DbSet<Catalogue> Catalogues {get;set;}
    DbSet<Counterparty> Counterparties {get;set;}
    DbSet<CurrencyUnit> CurrencyUnits {get;set;}
    DbSet<Participation> Participations {get;set;}
    DbSet<Position> Positions {get;set;}
    DbSet<Project> Projects {get;set;}
    DbSet<ProjectUpdateLog> ProjectUpdateLogs {get;set;}
    DbSet<ReportedProject> ReportedProjects {get;set;}
    DbSet<Sponsor> Sponsors {get;set;}
    DbSet<RefreshToken> RefreshTokens {get; set;}
    DbSet<File> Files {get; set;}
    DbSet<FileType> FileTypes {get; set;}

    Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default);
}
