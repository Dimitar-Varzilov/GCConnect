using GCConnect.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace GCConnect.Services.Persistence;

public class GCConnectDbContext : DbContext
{
    public GCConnectDbContext(DbContextOptions<GCConnectDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<TeamRole> TeamRoles => Set<TeamRole>();
    public DbSet<Leave> Leaves => Set<Leave>();
    public DbSet<LeavePolicy> LeavePolicies => Set<LeavePolicy>();
    public DbSet<JobHistory> JobHistories => Set<JobHistory>();
    public DbSet<Report> Reports => Set<Report>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GCConnectDbContext).Assembly);
        // Soft-delete filters
        modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
        // filter leaves both by its own IsDeleted and the related user
        modelBuilder.Entity<Leave>().HasQueryFilter(l => !l.IsDeleted && !l.User.IsDeleted);
        // Конвенция: rowversion за всички BaseEntity.RowVersion
        foreach (var et in modelBuilder.Model.GetEntityTypes())
        {
            var rv = et.FindProperty(nameof(BaseEntity.RowVersion));
            if (rv != null) rv.IsConcurrencyToken = true;

            var dc = et.FindProperty(nameof(BaseEntity.DateCreated));
            if (dc != null && dc.ClrType == typeof(DateTimeOffset))
                dc.SetDefaultValueSql("SYSDATETIMEOFFSET()"); // допълва интерсептора
        }
        modelBuilder.ApplyBaseConventions();
        base.OnModelCreating(modelBuilder);
    }
}
