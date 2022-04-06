using Microsoft.AspNetCore.Identity;

namespace RealSite.Domain
{
    public class UserModel : IdentityUser
    {
        public string Organization { get; set; }
        public string ContactPerson { get; set; }
        public string Phone { get; set; }

    }
}
