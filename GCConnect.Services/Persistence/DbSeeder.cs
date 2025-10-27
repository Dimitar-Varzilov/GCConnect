using GCConnect.Common.Entities;
using GCConnect.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace GCConnect.Services.Persistence;

public static class DbSeeder
{
    public static async Task SeedAsync(GCConnectDbContext db)
    {

        if (!await db.TeamRoles.AnyAsync())
        {
            db.TeamRoles.AddRange(
                new TeamRole { Name = "Junior" },
                new TeamRole { Name = "Mid" },
                new TeamRole { Name = "Senior" },
                new TeamRole { Name = "Team Lead" }
            );
        }

        if (!await db.Teams.AnyAsync())
        {
            db.Teams.AddRange(
                new Team { Name = "Model Ex" },
                new Team { Name = "DBMS" },
                new Team { Name = "Sunstone" },
                new Team { Name = "QA" },
                new Team { Name = "GC Analytics Portal" }
            );
        }

        await db.SaveChangesAsync();


        if (!await db.Users.AnyAsync(u => !u.IsDeleted && u.Email == "admin@astea.net"))
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow.Date);
            db.Users.Add(new User
            {
                Email = "admin@astea.net",
                FirstName = "System",
                LastName = "Admin",
                Role = UserRole.Admin,
                HireDate = today,
                BirthDate = today 
            });

            await db.SaveChangesAsync();
        }
    }
}
