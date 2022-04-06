using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace RealSite.Presentation.Identity.Roles.Commands.CreateRole
{
    public class CreateRoleCommandHandler
        : IRequestHandler<CreateRoleCommand, bool>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateRoleCommandHandler(RoleManager<IdentityRole> roleManager)
            => _roleManager = roleManager;

        public async Task<bool> Handle(CreateRoleCommand request,
            CancellationToken cancellationToken)
        {
            var role = new IdentityRole
            {
                Name = request.Name
            };
            IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(role.Name));
            if (result.Succeeded)
                return true;
            else
                return false;
        }
    }
}

