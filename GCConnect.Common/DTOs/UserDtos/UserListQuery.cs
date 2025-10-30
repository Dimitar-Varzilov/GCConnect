namespace GCConnect.Common.DTOs.Users;
public sealed class UserListQuery
{
    public int Page { get; init; } = 1;
    public int PageSize { get; init; } = 20;
    public string? Search { get; init; }          // search by FirstName, LastName or Email
    public Guid? TeamId { get; init; }
    public Guid? TeamRoleId { get; init; }
 

    // Sorting: "FirstName:asc", "LastName:desc", "HireDate:asc" etc.
    public string? Sort { get; init; }            // Field:[asc|desc]
}
