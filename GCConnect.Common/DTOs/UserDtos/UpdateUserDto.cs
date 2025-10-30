namespace GCConnect.Common.DTOs.Users;

public sealed class UpdateUserDto // dto for updating user details
{
    public  string? FirstName { get; init; }
    public  string? LastName { get; init; }
    public  DateOnly? BirthDate { get; init; }
}
