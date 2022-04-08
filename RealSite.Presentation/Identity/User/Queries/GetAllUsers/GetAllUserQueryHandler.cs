using MediatR;
using Microsoft.AspNetCore.Identity;
using RealSite.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealSite.Presentation.Identity.User.Queries.GetAllUsers
{
    public class GetAllUserQueryHandler
        : IRequestHandler<GetAllUserQuery, UserListVm>
    {
        private readonly UserManager<UserModel> _userManager;

        public GetAllUserQueryHandler(UserManager<UserModel> userManager)
            => _userManager = userManager;

        public async Task<UserListVm> Handle(GetAllUserQuery request,
            CancellationToken cancellationToken)
        {

            var allUser = _userManager.Users.ToList();

            return new UserListVm { Users = allUser };
        }

    }
}
