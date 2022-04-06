using MediatR;


namespace RealSite.Presentation.Identity.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommand : IRequest
    {
        public string Id { get; set; }
    }
}
