using GCConnect.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCConnect.Services.Persistence.Configurations;

public class LeavePolicyConfiguration : BaseEntityConfiguration<LeavePolicy>
{
    public override void Configure(EntityTypeBuilder<LeavePolicy> b)
    {
        base.Configure(b);
        b.ToTable("LeavePolicies");
       
        
        b.Property(x => x.QuotaDays).HasDefaultValue(20);
        b.Property(x => x.CarryOverDays).HasDefaultValue(0);
        
        
        b.HasOne(x => x.User)
         .WithMany(u => u.LeavePolicies)
         .HasForeignKey(x => x.UserId)
         .IsRequired()
         .OnDelete(DeleteBehavior.Cascade); b.HasOne(x => x.User).WithMany(u => u.LeavePolicies).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);

    }
}
