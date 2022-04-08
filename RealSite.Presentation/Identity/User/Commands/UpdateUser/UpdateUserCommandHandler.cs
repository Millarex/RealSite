using MediatR;
using Microsoft.AspNetCore.Identity;
using RealSite.Application.Common.Exceptions;
using RealSite.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace RealSite.Presentation.Identity.User.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, IdentityResult>
    {
        private readonly UserManager<UserModel> _userManager;

        public UpdateUserCommandHandler(UserManager<UserModel> userManager)
            => _userManager = userManager;

        public async Task<IdentityResult> Handle(UpdateUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user != null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }
            user.Email = request.Email;
            user.UserName = request.Email;
            user.Organization = request.Organization;
            user.ContactPerson = request.ContactPerson;
            user.Phone = request.Phone;

            var result = await _userManager.UpdateAsync(user);
            return result;
        }
    }
}
