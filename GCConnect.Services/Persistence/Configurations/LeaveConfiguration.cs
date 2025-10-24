using GCConnect.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCConnect.Services.Persistence.Configurations;

public class LeaveConfiguration : IEntityTypeConfiguration<Leave>
{
    public void Configure(EntityTypeBuilder<Leave> b)
    {
        b.ToTable("Leaves", tb =>
        {
            tb.HasCheckConstraint("CK_Leaves_FromTo", "[FromDate] <= [ToDate]");
            // по желание (ако държиш на тези string стойности):
            tb.HasCheckConstraint("CK_Leaves_Type", "[Type] IN (N'Paid', N'Unpaid', N'Sick')");
            tb.HasCheckConstraint("CK_Leaves_Status", "[Status] IN (N'Approved', N'Pending')");
        });
        b.Property(x => x.FromDate).HasColumnType("date");
        b.Property(x => x.ToDate).HasColumnType("date");
        b.Property(x => x.Type).HasMaxLength(30).IsRequired();
        b.Property(x => x.Status).HasMaxLength(30).IsRequired();
        b.Property(x => x.Note).HasMaxLength(300);
        b.HasIndex(x => new { x.UserId, x.FromDate, x.ToDate });


    }
}
