using GCConnect.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;

namespace GCConnect.Services.Persistence.Configurations;

public class LeaveConfiguration : BaseEntityConfiguration<Leave>
{
    public override void Configure(EntityTypeBuilder<Leave> b)
    {
        base.Configure(b);
        b.ToTable("Leaves", tb =>
        {
            tb.HasCheckConstraint("CK_Leaves_FromTo", "[FromDate] <= [ToDate]");
        });



        b.Property(x => x.FromDate).HasColumnType("date");
        b.Property(x => x.ToDate).HasColumnType("date");
        b.Property(x => x.Type).HasMaxLength(30).IsRequired();
        b.Property(x => x.Status).HasMaxLength(30).IsRequired();
        b.Property(x => x.Note).HasMaxLength(300);
        b.HasOne(x => x.User)
            .WithMany(u => u.Leaves)
            .HasForeignKey(x => x.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        b.HasIndex(x => new { x.UserId, x.FromDate, x.ToDate });
    }
}
