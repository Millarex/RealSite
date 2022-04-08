using FluentValidation;


namespace RealSite.Presentation.Identity.User.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(createUserCommand =>
                createUserCommand.Email).NotEmpty().EmailAddress();
            RuleFor(createUserCommand =>
                createUserCommand.Organization).NotEmpty().MaximumLength(50);
            RuleFor(createUserCommand =>
                createUserCommand.ContactPerson).NotEmpty().MaximumLength(50);
            RuleFor(createUserCommand =>
                createUserCommand.Phone).NotEmpty();
        }
    }
}
