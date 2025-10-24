namespace GCConnect.Common.Entities;

using System.Collections.Generic;
public class Team : BaseEntity
{
    public string Name { get; set; } = null!;
    public ICollection<User> Users { get; private set; } = new HashSet<User>();
}
