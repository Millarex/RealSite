using MediatR;
using RealSite.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealSite.Presentation.Identity.User.Queries.GetUser
{
    public class GetUserQuery : IRequest<UpdateUserViewModel>
    {
        public string Id { get; set; }
    }
}
