using FluentValidation;
using GCConnect.Common.DTOs.Users;

public sealed class AdminUpdateUserDtoValidator : AbstractValidator<AdminUpdateUserDto>
{
    public AdminUpdateUserDtoValidator()
    {
        // Accept only valid GUIDs, but nullable
        When(x => x.TeamId.HasValue, () =>
        {
            RuleFor(x => x.TeamId!.Value)
                .NotEqual(Guid.Empty)
                .WithMessage("TeamId must be a non-empty GUID.");
        });

        When(x => x.TeamRoleId.HasValue, () =>
        {
            RuleFor(x => x.TeamRoleId!.Value)
                .NotEqual(Guid.Empty)
                .WithMessage("TeamRoleId must be a non-empty GUID.");
        });

    }
}
