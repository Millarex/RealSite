using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RealSite.Persistance.Data
{
    public class UserModel : IdentityUser
    {
        public string Organization { get; set; }
        public string ContactPerson { get; set; }
        //[RegularExpression(@"0-9+-")]
        public string Phone { get; set; }

    }
}
