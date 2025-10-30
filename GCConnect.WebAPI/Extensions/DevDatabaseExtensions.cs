using GCConnect.Services.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GCConnect.WebAPI.Extensions;

public static class DevDatabaseExtensions
{

    /// В Dev пуска миграциите и seed-ва начални данни.

    public static async Task UseDevDatabaseAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<GCConnectDbContext>();
        var logger = scope.ServiceProvider
                         .GetRequiredService<ILoggerFactory>()
                         .CreateLogger("DbInit");

        try
        {
            await db.Database.MigrateAsync();
            logger.LogInformation("Database migration completed.");

            // Only run seed if there are no user tables (db is empty)
            var hasAnyTables = await db.Database.ExecuteSqlRawAsync(
                "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'dbo'") > 0;
            if (!hasAnyTables)
            {
                await DbSeeder.SeedAsync(db);
                logger.LogInformation("Database seeded.");
            }
            else
            {
                logger.LogInformation("Database already contains data. Skipping seed.");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Database creation/migration/seed failed");
            throw;
        }
    }
}
