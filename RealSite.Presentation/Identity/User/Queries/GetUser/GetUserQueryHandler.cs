using MediatR;
using Microsoft.AspNetCore.Identity;
using RealSite.Application.Common.Exceptions;
using RealSite.Domain;
using RealSite.Presentation.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace RealSite.Presentation.Identity.User.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UpdateUserViewModel>
    {
        private readonly UserManager<UserModel> _userManager;

        public GetUserQueryHandler(UserManager<UserModel> userManager)
            => _userManager = userManager;

        public async Task<UpdateUserViewModel> Handle(GetUserQuery request,
            CancellationToken cancellationToken)
        {
            UserModel user;
            if (request.Id == null)
                user = await _userManager.FindByEmailAsync(request.Email);
            else
                user = await _userManager.FindByIdAsync(request.Id);

            if (user != null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }
            var vm = new UpdateUserViewModel();
            vm.Email = user.Email;
            vm.Organization = user.Organization;
            vm.ContactPerson = user.ContactPerson;
            vm.Phone = user.Phone;

            return vm;
        }
    }
}
