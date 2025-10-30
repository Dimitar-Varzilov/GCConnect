// GCConnect.Common/DTOs/Users/UserDetailsDto.cs
using GCConnect.Common.Enums;

namespace GCConnect.Common.DTOs.Users;

public sealed class UserDetailsDto // dto for getting full user details
{
    public Guid Id { get; init; }
    public required string Email { get; init; } 
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public DateOnly BirthDate { get; init; }
    public DateOnly HireDate { get; init; }
    public bool IsActive { get; init; }

    public required UserRole UserRole { get; init; }
    public Guid? TeamId { get; init; }
    public string? TeamName { get; init; }

    public Guid? TeamRoleId { get; init; }
    public string? TeamRoleName { get; init; }

 
}
