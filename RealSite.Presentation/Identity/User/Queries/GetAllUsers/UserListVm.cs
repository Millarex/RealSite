using RealSite.Domain;
using System.Collections.Generic;


namespace RealSite.Presentation.Identity.User.Queries.GetAllUsers
{
    public class UserListVm
    {
        public IList<UserModel> Users { get; set; }
    }
}
