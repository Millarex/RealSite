using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RealSite.Application.Common.Exceptions;
using RealSite.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RealSite.Presentation.Identity.Roles.Queries.GetAllUserRole
{
    public class GetAllUserRoleQueryHandler
        : IRequestHandler<GetAllUserRoleQuery, UserRoleVm>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<UserModel> _userManager;
        private readonly IMapper _mapper;

        public GetAllUserRoleQueryHandler(RoleManager<IdentityRole> roleManager,
            UserManager<UserModel> userManager, IMapper mapper)
            => (_roleManager, _userManager, _mapper) = (roleManager, userManager, mapper);

        public async Task<UserRoleVm> Handle(GetAllUserRoleQuery request,
           CancellationToken cancellationToken)
        {
            UserModel user = await _userManager.FindByIdAsync(request.UserId);
            if (user != null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = _roleManager.Roles.ToList();

            UserRoleVm userRoleVm = _mapper.Map<UserRoleVm>(user);
            userRoleVm.AllRoles = allRoles;
            userRoleVm.UserRoles = userRoles;

            return userRoleVm;
        }
    }

}
