using GCConnect.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCConnect.Services.Persistence.Configurations;

public class TeamConfiguration : BaseEntityConfiguration<Team>
{
    public override void Configure(EntityTypeBuilder<Team> b)
    {
        base.Configure(b);
        b.ToTable("Teams");
        
        b.Property(x => x.Name).IsRequired().HasMaxLength(100);
        b.HasIndex(x => x.Name).IsUnique();
   
    }
}
