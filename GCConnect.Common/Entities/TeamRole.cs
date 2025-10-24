using System.Collections.Generic;

namespace GCConnect.Common.Entities;

public class TeamRole : BaseEntity
{
    public string Name { get; set; } = null!;
    public ICollection<User> Users { get; private set; } = new HashSet<User>();
}
