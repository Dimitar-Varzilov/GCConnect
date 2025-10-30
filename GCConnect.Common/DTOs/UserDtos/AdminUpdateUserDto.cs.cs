
using GCConnect.Common.Enums;

namespace GCConnect.Common.DTOs.Users;

public sealed class AdminUpdateUserDto // dto for admin updating user details
{


    public UserRole? Role { get; init; } 

    public Guid? TeamId { get; init; }

    public Guid? TeamRoleId { get; init; }
}
