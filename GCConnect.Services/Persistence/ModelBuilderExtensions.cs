using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GCConnect.Services.Persistence;

public static class ModelBuilderExtensions
{
    public static void ApplyBaseConventions(this ModelBuilder modelBuilder)
    {
        foreach (var et in modelBuilder.Model.GetEntityTypes())
        {
            // RowVersion -> rowversion + concurrency
            var rv = et.FindProperty("RowVersion");
            if (rv != null && rv.ClrType == typeof(byte[]))
            {
                rv.IsConcurrencyToken = true;
                rv.ValueGenerated = ValueGenerated.OnAddOrUpdate;
                rv.SetColumnType("rowversion");
            }

            // DateCreated default UTC
            var dc = et.FindProperty("DateCreated");
            if (dc != null && dc.ClrType == typeof(DateTimeOffset))
            {
                dc.SetDefaultValueSql("SYSUTCDATETIME()");
            }
        }
    }
}
