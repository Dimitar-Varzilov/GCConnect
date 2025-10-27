using GCConnect.Common.Entities;
using GCConnect.Common.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCConnect.Services.Persistence.Configurations;

public class UserConfiguration : BaseEntityConfiguration<User>
{
   
     public override void Configure(EntityTypeBuilder<User> b)
     { 
        base.Configure(b);
        b.ToTable("Users", tb =>
        {
            // CHECK за enum UserRole (SQL Server синтаксис)
            tb.HasCheckConstraint("CK_Users_Role_Enum_Valid", "[Role] IN (1, 2)");
        });
        

        b.Property(x => x.Email).IsRequired().HasMaxLength(256);
        b.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        b.Property(x => x.LastName).IsRequired().HasMaxLength(100);


        b.Property(x => x.BirthDate).HasColumnType("date");
        b.Property(x => x.HireDate).HasColumnType("date");

        b.Property(x => x.Role)
            .HasConversion<int>()                 
            .IsRequired();

        b.HasIndex(x => x.Email).IsUnique();


        b.HasOne(x => x.Team)
            .WithMany(t => t.Users)
            .HasForeignKey(x => x.TeamId)
            .OnDelete(DeleteBehavior.Restrict);

        b.HasOne(x => x.TeamRole)
            .WithMany(tr => tr.Users)
            .HasForeignKey(x => x.TeamRoleId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
