using MediatR;


namespace RealSite.Presentation.Identity.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommand : IRequest<bool>
    {
        public string Id { get; set; }
    }
}
