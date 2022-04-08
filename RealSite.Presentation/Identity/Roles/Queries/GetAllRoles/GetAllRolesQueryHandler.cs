using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RealSite.Presentation.Identity.Roles.Queries.GetAllRoles
{
    public class GetAllRolesQueryHandler
        : IRequestHandler<GetAllRolesQuery, RoleListVm>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public GetAllRolesQueryHandler(RoleManager<IdentityRole> roleManager)
            => _roleManager = roleManager;

        public async Task<RoleListVm> Handle(GetAllRolesQuery request,
            CancellationToken cancellationToken)
        {
            var allRoles = _roleManager.Roles.ToList();

            return new RoleListVm { Roles = allRoles };
        }

    }
}
