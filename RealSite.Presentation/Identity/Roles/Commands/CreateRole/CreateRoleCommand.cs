using MediatR;


namespace RealSite.Presentation.Identity.Roles.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
