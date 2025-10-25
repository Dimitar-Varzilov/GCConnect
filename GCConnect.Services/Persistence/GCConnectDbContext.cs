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
        modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Leave>().HasQueryFilter(l => !l.IsDeleted && !l.User.IsDeleted);
        modelBuilder.Entity<LeavePolicy>().HasQueryFilter(lp => !lp.IsDeleted && !lp.User.IsDeleted);
        base.OnModelCreating(modelBuilder);
    }
}
