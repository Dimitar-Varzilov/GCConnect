using GCConnect.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCConnect.Services.Persistence.Configurations;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> b)
    {
        b.HasKey(x => x.Id);
        b.Property(x => x.DateCreated)
         .HasDefaultValueSql("SYSUTCDATETIME()");   
        b.Property(x => x.IsDeleted)
         .HasDefaultValue(false);
        b.Property(x => x.RowVersion)
         .IsRowVersion();                           
    }
}
