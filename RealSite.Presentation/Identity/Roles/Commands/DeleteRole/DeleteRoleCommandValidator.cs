using FluentValidation;
using System;

namespace RealSite.Presentation.Identity.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleCommandValidator()
        {
            RuleFor(DeleteRoleCommand =>
                DeleteRoleCommand.Id).NotEmpty();
        }
    }
}
