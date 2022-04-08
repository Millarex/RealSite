using MediatR;
using System.Collections.Generic;


namespace RealSite.Presentation.Identity.User.Commands.UpdateUserRole
{
    public class UpdateUserRoleCommand : IRequest<bool>
    {
        public string UserId { get; set; }
        public List<string> Roles { get; set; }
    }
}
