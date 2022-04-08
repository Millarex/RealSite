using MediatR;
using Microsoft.AspNetCore.Identity;
using RealSite.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace RealSite.Presentation.Identity.User.Commands.CreateUser
{
    public class CreateUserCommandHandler
     : IRequestHandler<CreateUserCommand, IdentityResult>
    {
        private readonly UserManager<UserModel> _userManager;

        public CreateUserCommandHandler(UserManager<UserModel> userManager)
            => _userManager = userManager;

        public async Task<IdentityResult> Handle(CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = new UserModel
            {
                Email = request.Email,
                UserName = request.Email,
                Organization = request.Organization,
                ContactPerson = request.ContactPerson,
                Phone = request.Phone
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            return result;
        }
    }
}
