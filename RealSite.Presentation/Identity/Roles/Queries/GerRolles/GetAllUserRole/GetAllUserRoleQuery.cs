using MediatR;

namespace RealSite.Presentation.Identity.Roles.Queries.GerRolles.GetAllUserRole
{
    public class GetAllUserRoleQuery : IRequest<UserRoleVm>
    {
        public string UserId { get; set; }
    }
}
