
using GCConnect.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

public class AuditSaveChangesInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData e, InterceptionResult<int> result)
    {
        SetAudit(e.Context);
        return base.SavingChanges(e, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData e, InterceptionResult<int> result, CancellationToken ct = default)
    {
        SetAudit(e.Context);
        return base.SavingChangesAsync(e, result, ct);
    }

    private static void SetAudit(DbContext? ctx)
    {
        if (ctx is null) return;

        var now = DateTimeOffset.UtcNow;

        foreach (var entry in ctx.ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                if (entry.Property(x => x.DateCreated).CurrentValue == default)
                    entry.Property(x => x.DateCreated).CurrentValue = now;
            }
        }
    }
}
