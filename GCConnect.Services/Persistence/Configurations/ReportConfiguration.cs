using GCConnect.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCConnect.Services.Persistence.Configurations;

public class ReportConfiguration : BaseEntityConfiguration<Report>
{
    public override void Configure(EntityTypeBuilder<Report> b)
    {
        base.Configure(b);
        b.ToTable("Reports");
        
        b.Property(x => x.Name).IsRequired().HasMaxLength(120);
        b.Property(x => x.BlobUrl).IsRequired().HasMaxLength(1024);
       
    }
}
