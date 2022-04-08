using FluentValidation;

namespace RealSite.Presentation.Identity.User.Queries.GetUser
{
    public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(GetAllUserRoleQuery =>
               GetAllUserRoleQuery.Id).NotEmpty();
        }
    }
}
