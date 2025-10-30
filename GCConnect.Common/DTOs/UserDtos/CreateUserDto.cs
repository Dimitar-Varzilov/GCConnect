namespace GCConnect.Common.DTOs.Users;

public sealed class CreateUserDto
{
    public required string Email { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }

    public required DateOnly BirthDate { get; init; }
    public required DateOnly HireDate { get; init; }

    public Guid? TeamId { get; init; }
    public Guid? TeamRoleId { get; init; }
}
