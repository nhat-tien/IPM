using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        // builder.HasMany(e => e.Users)
        //     .WithMany(e => e.Projects)
        //     .UsingEntity<Participation>(
        //             l => l.HasOne<User>().WithMany().HasForeignKey(e => e.UserId),
        //             r => r.HasOne<Project>().WithMany().HasForeignKey(e => e.ProjectId)
        //     );
        foreach (var fk in builder.Metadata.GetForeignKeys())
        {
            var propName = fk.Properties.FirstOrDefault()?.Name;

            if (propName?.EndsWith("Id") == true && !fk.IsRequired && propName != "ProjectId")
            {
                fk.DeleteBehavior = DeleteBehavior.SetNull;
            }
        }
    }
}
