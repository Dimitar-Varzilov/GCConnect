using System.ComponentModel.DataAnnotations;

namespace GCConnect.Common.Entities;

// BaseEntity.cs
public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public bool IsDeleted { get; set; } = false;

    public byte[]? RowVersion { get; set; }
}
