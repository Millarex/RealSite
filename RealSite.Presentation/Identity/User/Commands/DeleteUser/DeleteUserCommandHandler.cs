using MediatR;
using Microsoft.AspNetCore.Identity;
using RealSite.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace RealSite.Presentation.Identity.User.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly UserManager<UserModel> _userManager;

        public DeleteUserCommandHandler(UserManager<UserModel> userManager)
            => _userManager = userManager;

        public async Task<bool> Handle(DeleteUserCommand request,
           CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return true;
            }
            return false;
        }
    }
}
