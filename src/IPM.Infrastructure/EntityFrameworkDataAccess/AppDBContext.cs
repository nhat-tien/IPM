namespace IPM.Infrastructure;

using Microsoft.EntityFrameworkCore;
using IPM.Infrastructure.Entities;

public class AppDBContext: DbContext
{
    public DbSet<User> Users {get; set;}
    public DbSet<AffiliatedUnit> AffiliatedUnits {get;set;}
    public DbSet<AidType> AidTypes {get;set;}
    public DbSet<ApprovingAgency> ApprovingAgencies {get;set;}
    public DbSet<AttachedFile> AttachedFiles {get;set;}
    public DbSet<Catalogue> Catalogues {get;set;}
    public DbSet<Counterparty> Counterparties {get;set;}
    public DbSet<CurrencyUnit> CurrencyUnits {get;set;}
    public DbSet<Participation> Participations {get;set;}
    public DbSet<Position> Positions {get;set;}
    public DbSet<Project> Projects {get;set;}
    public DbSet<ProjectUpdateLog> ProjectUpdateLogs {get;set;}
    public DbSet<ReportedProject> ReportedProjects {get;set;}
    public DbSet<Role> Roles {get;set;}
    public DbSet<Sponsor> Sponsors {get;set;}

}
