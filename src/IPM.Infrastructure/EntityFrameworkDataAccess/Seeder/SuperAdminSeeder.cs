using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Seeder;

public class SuperAdminSeeder
{
    public static async Task SeedSuperAdminAsync(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
        var config = serviceProvider.GetRequiredService<IConfiguration>();

        string superAdminEmail = config["InitialUser:Email"]!;
        string superAdminPassword = config["InitialUser:Password"]!; 
        string superAdminFirstName = config["InitialUser:FirstName"]!;
        string superAdminLastName = config["InitialUser:LastName"]!;

        var adminUser = await userManager.FindByEmailAsync(superAdminEmail);
        if (adminUser == null)
        {
            adminUser = new User() 
            {
                UserName = superAdminEmail,
                Email = superAdminEmail,
                EmailConfirmed = true,
                IsVerified = true,
                FirstName = superAdminFirstName,
                LastName = superAdminLastName 
            };

            var result = await userManager.CreateAsync(adminUser, superAdminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
            else
            {
                throw new Exception("Failed to create super admin:\n" +
                    string.Join("\n", result.Errors.Select(e => e.Description)));
            }
        }
    }
}
