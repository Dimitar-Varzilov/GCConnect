using GCConnect.Common.Entities;
using GCConnect.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace GCConnect.Services.Persistence;

public static class DbSeeder
{
    public static async Task SeedAsync(GCConnectDbContext db)
    {
        // 1) TeamRoles (ако липсват)
        if (!await db.TeamRoles.AnyAsync())
        {
            db.TeamRoles.AddRange(
                new TeamRole { Name = "Junior" },
                new TeamRole { Name = "Mid" },
                new TeamRole { Name = "Senior" },
                new TeamRole { Name = "Team Lead" }
            );
        }

        // 2) Teams (ако липсват)
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

        // Запиши, за да ги имаме в БД преди да ги търсим
        await db.SaveChangesAsync();

        // 3) Admin user (ако липсва)
        if (!await db.Users.AnyAsync(u => !u.IsDeleted && u.Email == "admin@astea.net"))
        {
            // Вземи вече записаните Team/TeamRole
            var qaTeam = await db.Teams.SingleAsync(t => t.Name == "QA");
            var senior = await db.TeamRoles.SingleAsync(tr => tr.Name == "Senior");

            var today = DateOnly.FromDateTime(DateTime.UtcNow.Date);

            db.Users.Add(new User
            {
                Email = "admin@astea.net",
                FirstName = "System",
                LastName = "Admin",
                Role = UserRole.Admin,
                TeamId = qaTeam.Id,
                TeamRoleId = senior.Id,
                HireDate = today,
                BirthDate = today // или null, ако колоната е nullable
            });

            await db.SaveChangesAsync();
        }
    }
}
