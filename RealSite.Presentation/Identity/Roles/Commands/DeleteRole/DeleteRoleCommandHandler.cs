using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RealSite.Presentation.Identity.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, bool>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public DeleteRoleCommandHandler(RoleManager<IdentityRole> roleManager)
            => _roleManager = roleManager;

        public async Task<bool> Handle(DeleteRoleCommand request,
           CancellationToken cancellationToken)
        {

            IdentityRole role = await _roleManager.FindByIdAsync(request.Id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return true;
            }
            return false;
        }
    }
}
