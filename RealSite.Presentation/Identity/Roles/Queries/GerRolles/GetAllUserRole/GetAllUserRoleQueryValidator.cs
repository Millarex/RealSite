using FluentValidation;

namespace RealSite.Presentation.Identity.Roles.Queries.GerRolles.GetAllUserRole
{
    public class GetAllUserRoleQueryValidator : AbstractValidator<GetAllUserRoleQuery>
    {
        public GetAllUserRoleQueryValidator()
        {
            RuleFor(GetAllUserRoleQuery =>
               GetAllUserRoleQuery.UserId).NotEmpty();
        }
    }
}
