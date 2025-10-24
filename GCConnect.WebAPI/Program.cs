using GCConnect.Services.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GCConnect.WebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<GCConnectDbContext>(opt =>
            {
                opt.AddInterceptors(new AuditSaveChangesInterceptor());
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Sql"), sql =>
                {
                    sql.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                    sql.MigrationsAssembly(typeof(GCConnectDbContext).Assembly.GetName().Name);
                });
            });

            var app = builder.Build();

            // Dev: auto-migrate + seed
            if (app.Environment.IsDevelopment())
            {
                using var scope = app.Services.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<GCConnectDbContext>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                try
                {
                    db.Database.Migrate();
                    await DbSeeder.SeedAsync(db); // <- вече може да се await-не
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Database migration/seed failed");
                    throw;
                }
            }

            await app.RunAsync(); // <- async вариантът на Run
        }
    }
}
