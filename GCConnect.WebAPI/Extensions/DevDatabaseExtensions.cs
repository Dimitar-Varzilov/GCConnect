using GCConnect.Services.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GCConnect.WebAPI.Extensions;

public static class DevDatabaseExtensions
{
    
    /// В Dev пуска миграциите и seed-ва начални данни.
   
    public static async Task UseDevDatabaseAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var env = scope.ServiceProvider.GetRequiredService<IHostEnvironment>();
        var db = scope.ServiceProvider.GetRequiredService<GCConnectDbContext>();
        var logger = scope.ServiceProvider
                         .GetRequiredService<ILoggerFactory>()
                         .CreateLogger("DbInit");

        try
        {
            await db.Database.MigrateAsync();
            await DbSeeder.SeedAsync(db);
            logger.LogInformation("Database migrated and seeded.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Database migration/seed failed");
            throw;
        }
    }
}
