using GCConnect.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCConnect.Services.Persistence.Configurations;

public class TeamRoleConfiguration : BaseEntityConfiguration<TeamRole>
{
    public override void Configure(EntityTypeBuilder<TeamRole> b)
    {
        base.Configure(b);
        b.ToTable("TeamRoles");
        
        b.Property(x => x.Name).IsRequired().HasMaxLength(50);
        b.HasIndex(x => x.Name).IsUnique();
   
    }
}
