using GCConnect.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCConnect.Services.Persistence.Configurations;

public class LeavePolicyConfiguration : IEntityTypeConfiguration<LeavePolicy>
{
    public void Configure(EntityTypeBuilder<LeavePolicy> b)
    {
        b.ToTable("LeavePolicies");
        b.HasKey(x => x.Id);

        b.Property(x => x.QuotaDays).HasDefaultValue(20);
        b.Property(x => x.CarryOverDays).HasDefaultValue(0);
        b.Property(x => x.DateCreated).HasDefaultValueSql("SYSDATETIMEOFFSET()");
        b.HasOne(x => x.User).WithMany(u => u.LeavePolicies).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);

    }
}
