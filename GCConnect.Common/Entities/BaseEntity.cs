using System.ComponentModel.DataAnnotations;

namespace GCConnect.Common.Entities;

// BaseEntity.cs
public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    // Let DB set default value via HasDefaultValueSql in configurations
    public DateTimeOffset DateCreated { get; set; }
    public bool IsDeleted { get; set; } = false;

    public byte[]? RowVersion { get; set; }
}
