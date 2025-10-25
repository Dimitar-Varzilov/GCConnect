using GCConnect.Common.Enums;

namespace GCConnect.Common.Entities;

public class Report : BaseEntity
{
    public string Name { get; set; } = null!;
    public string BlobUrl { get; set; } = null!;
    public JobHistory? JobHistory { get; set; }
}