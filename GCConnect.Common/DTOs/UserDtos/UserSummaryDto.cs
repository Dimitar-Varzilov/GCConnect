namespace GCConnect.Common.DTOs.Users;

public sealed class UserSummaryDto
{
    public Guid Id { get; init; }

    public required string Email { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }

    public bool IsActive { get; init; }

    public Guid? TeamId { get; init; }
    public string? TeamName { get; init; }

    public Guid? TeamRoleId { get; init; }
    public string? TeamRoleName { get; init; }
}
