using GCConnect.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCConnect.Services.Persistence.Configurations;

public class JobHistoryConfiguration : IEntityTypeConfiguration<JobHistory>
{
    public void Configure(EntityTypeBuilder<JobHistory> b)
    {
        b.ToTable("JobHistory");
        b.HasKey(x => x.Id);

        b.Property(x => x.Type).HasConversion<int>();
        b.Property(x => x.Status).HasConversion<int>();
        b.Property(x => x.ResultUrl).HasMaxLength(1024);

        b.Property(x => x.StartedAt).HasDefaultValueSql("SYSDATETIMEOFFSET()");
        b.Property(x => x.Logs).HasMaxLength(4000);


        b.HasOne(x => x.TriggeredByUser)
            .WithMany(u => u.TriggeredJobs)
            .HasForeignKey(x => x.TriggeredByUserId)
            .OnDelete(DeleteBehavior.SetNull);

        b.HasOne(x => x.Report)
            .WithOne(r => r.JobHistory)
            .HasForeignKey<JobHistory>(x => x.ReportId)
            .OnDelete(DeleteBehavior.SetNull);

        b.HasIndex(x => x.TriggeredByUserId);
        b.HasIndex(x => x.ReportId)
            .IsUnique()
            .HasFilter("[ReportId] IS NOT NULL"); // nullable 1:1
        b.HasIndex(x => x.StartedAt);
    }
}
