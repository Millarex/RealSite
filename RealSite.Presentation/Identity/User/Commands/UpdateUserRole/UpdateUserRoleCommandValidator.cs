using FluentValidation;


namespace RealSite.Presentation.Identity.User.Commands.UpdateUserRole
{
    public class UpdateUserRoleCommandValidator : AbstractValidator<UpdateUserRoleCommand>
    {
        public UpdateUserRoleCommandValidator()
        {
            RuleFor(UpdateUserRoleCommand =>
                UpdateUserRoleCommand.UserId).NotEmpty();
            RuleFor(UpdateUserRoleCommand =>
                UpdateUserRoleCommand.Roles).NotEmpty();
        }
    }
}
