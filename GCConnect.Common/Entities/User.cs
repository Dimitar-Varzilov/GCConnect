using GCConnect.Common.Entities;
using GCConnect.Common.Enums;

public class User : BaseEntity
{
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public DateOnly HireDate { get; set; }
    public UserRole Role { get; set; }

    // Optional external id and active flag
   // public string? OktaId { get; set; }
  //  public bool IsActive { get; set; } = true;

    public Guid? TeamId { get; set; }
    public Team? Team { get; set; }

    public Guid? TeamRoleId { get; set; }
    public TeamRole? TeamRole { get; set; }


    public ICollection<Leave> Leaves { get; set; } = new List<Leave>();
    public ICollection<LeavePolicy> LeavePolicies { get; set; } = new List<LeavePolicy>();
    public ICollection<JobHistory> TriggeredJobs { get; set; } = new List<JobHistory>();
}
