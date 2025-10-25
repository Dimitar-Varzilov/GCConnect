using GCConnect.Common.Entities;
using GCConnect.Common.Enums;

namespace GCConnect.Common.Entities;

public class Leave : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public DateOnly FromDate { get; set; }
    public DateOnly ToDate { get; set; }

    public LeaveType Type { get; set; } = LeaveType.Paid;     // "Paid" | "Unpaid" | "Sick"
    public LeaveStatus Status { get; set; } = LeaveStatus.Pending;// "Pending" | "Approved"
    public string? Note { get; set; }
}
