namespace IPM.Infrastructure.EntityFrameworkDataAccess;

using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using IPM.Infrastructure.EntityFrameworkDataAccess.Seeds;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDBContext : IdentityDbContext<User> 
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options) { }

    public DbSet<AffiliatedUnit> AffiliatedUnits { get; set; } = null!;
    public DbSet<AidType> AidTypes { get; set; } = null!;
    public DbSet<ApprovingAgency> ApprovingAgencies { get; set; } = null!;
    public DbSet<Catalogue> Catalogues { get; set; } = null!;
    public DbSet<Counterparty> Counterparties { get; set; } = null!;
    public DbSet<CurrencyUnit> CurrencyUnits { get; set; } = null!;
    public DbSet<Participation> Participations { get; set; } = null!;
    public DbSet<Position> Positions { get; set; } = null!;
    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<ProjectUpdateLog> ProjectUpdateLogs { get; set; } = null!;
    public DbSet<ReportedProject> ReportedProjects { get; set; } = null!;
    public DbSet<Sponsor> Sponsors { get; set; } = null!;
    public DbSet<RefreshToken> RefreshTokens {get; set;} = null!;
    public DbSet<File> Files {get; set;} = null!;
    public DbSet<FileType> FileTypes {get; set;} = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();

            if (tableName != null && tableName.StartsWith("AspNet"))
            {
                entityType.SetTableName(tableName.Substring(6));
            }
        }
        builder.ApplyConfiguration(new RefreshTokenConfiguration());
        // builder.HasDefaultSchema();
        builder.RoleSeed();
    }
}
