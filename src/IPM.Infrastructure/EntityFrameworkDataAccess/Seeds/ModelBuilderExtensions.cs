using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Seeds;

public static class ModelBuilderExtensions
{
    public static void RoleSeed(this ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<IdentityRole>()
            .HasData(
                new IdentityRole()
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                },
                new IdentityRole()
                {
                    Id = "2",
                    Name = "Manager",
                    NormalizedName = "MANAGER",
                },
                new IdentityRole()
                {
                    Id = "3",
                    Name = "User",
                    NormalizedName = "USER",
                }
            );
    }
}
