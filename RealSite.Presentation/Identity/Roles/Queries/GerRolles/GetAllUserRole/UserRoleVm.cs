using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RealSite.Application.Common.Mappings;
using RealSite.Domain;
using System.Collections.Generic;

namespace RealSite.Presentation.Identity.Roles.Queries.GerRolles.GetAllUserRole
{
    public class UserRoleVm : IMapWith<UserModel>
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public List<IdentityRole> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserModel, UserRoleVm>()
                .ForMember(UserRoleVm => UserRoleVm.UserId,
                    opt => opt.MapFrom(UserModel => UserModel.Id))
                .ForMember(UserRoleVm => UserRoleVm.UserEmail,
                    opt => opt.MapFrom(UserModel => UserModel.Email));
        }
    }
}
