using FluentValidation;
using System;

namespace RealSite.Presentation.Identity.Roles.Commands.CreateRole
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(createRoleCommand =>
                createRoleCommand.Name).NotEmpty().MaximumLength(250);
        }
    }
}

