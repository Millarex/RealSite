using MediatR;


namespace RealSite.Presentation.Identity.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public string Id { get; set; }
    }
}
