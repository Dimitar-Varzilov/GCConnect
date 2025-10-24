using GCConnect.Common.Entities;

namespace GCConnect.Common.Entities;

public class Leave : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public DateOnly FromDate { get; set; }
    public DateOnly ToDate { get; set; }

    public string Type { get; set; } = "Paid";     // "Paid" | "Unpaid" | "Sick"
    public string Status { get; set; } = "Approved"; // MVP
    public string? Note { get; set; }
}
