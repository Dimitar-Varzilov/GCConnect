using GCConnect.Common.Entities;

namespace GCConnect.Common.Entities;

public class LeavePolicy : BaseEntity
{
    public int Year { get; set; }
    public int QuotaDays { get; set; } = 20;
    public int CarryOverDays { get; set; } = 0;

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

}
