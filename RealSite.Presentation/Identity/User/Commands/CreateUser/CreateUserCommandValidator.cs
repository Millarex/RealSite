using FluentValidation;


namespace RealSite.Presentation.Identity.User.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(createUserCommand =>
                createUserCommand.Email).NotEmpty().EmailAddress();
            RuleFor(createUserCommand =>
                createUserCommand.Organization).NotEmpty().MaximumLength(50);
            RuleFor(createUserCommand =>
                createUserCommand.ContactPerson).NotEmpty().MaximumLength(50);
            RuleFor(createUserCommand =>
                createUserCommand.Phone).NotEmpty();
            RuleFor(createUserCommand =>
                createUserCommand.Password).NotEmpty().MinimumLength(6);
            RuleFor(createUserCommand =>
                createUserCommand.PasswordConfirm).NotEmpty();
        }
    }
}
