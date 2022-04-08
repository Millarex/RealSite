using FluentValidation;

namespace RealSite.Presentation.Identity.User.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(DeleteRoleCommand =>
                DeleteRoleCommand.Id).NotEmpty();
        }
    }
}
