using IPM.Infrastructure.EntityFrameworkDataAccess.Seeder;

namespace IPM.WebApi.Cli;

public class CliHandler
{
    public static async Task Handle(string[] args, WebApplication app)
    {
        switch (args[0].ToLower())
        {
            case "seed-admin":
                await SeedAdmin(app);
                break;
            default:
                Console.WriteLine("Unknown Command");
                break;
        }
    }

    public static async Task SeedAdmin(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            await SuperAdminSeeder.SeedSuperAdminAsync(services);
            Console.WriteLine("✅ Super Admin seeded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error seeding Super Admin: " + ex.Message);
        }
    }
}
