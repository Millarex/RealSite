using MediatR;
using Microsoft.AspNetCore.Identity;
using RealSite.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealSite.Presentation.Identity.User.Commands.UpdateUserRole
{
    public class UpdateUserRoleCommandHandler
         : IRequestHandler<UpdateUserRoleCommand, bool>
    {
        private readonly UserManager<UserModel> _userManager;

        public UpdateUserRoleCommandHandler(RoleManager<IdentityRole> roleManager,
            UserManager<UserModel> userManager)
            => _userManager = userManager;

        public async Task<bool> Handle(UpdateUserRoleCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                return false;

            var userRoles = await _userManager.GetRolesAsync(user);

            var addedRoles = request.Roles.Except(userRoles);
            var removedRoles = userRoles.Except(request.Roles);
            await _userManager.AddToRolesAsync(user, addedRoles);
            await _userManager.RemoveFromRolesAsync(user, removedRoles);

            return true;

        }
    }
}

