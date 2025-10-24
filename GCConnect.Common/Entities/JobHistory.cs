namespace GCConnect.Common.Entities;

using GCConnect.Common.Enums;

public class JobHistory : BaseEntity
{
    public JobType Type { get; set; }
    public JobStatus Status { get; set; } = JobStatus.Queued;

    // StartedAt will be set by the database default (SYSDATETIMEOFFSET()) configured in EF
    public DateTimeOffset StartedAt { get; set; }
    public DateTimeOffset? FinishedAt { get; set; }

    public Guid? TriggeredByUserId { get; set; }     
    public User? TriggeredByUser { get; set; }

    public string? ResultUrl { get; set; }          
    public string? Logs { get; set; }

    public Guid? ReportId { get; set; }
    public Report? Report { get; set; }
}