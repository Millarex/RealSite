using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RealSite.Application.Common.Mappings;
using RealSite.Presentation.ViewModels;


namespace RealSite.Presentation.Identity.User.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<IdentityResult>, IMapWith<RegisterViewModel>
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Organization { get; set; }
        public string ContactPerson { get; set; }
        public string Phone { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserViewModel, UpdateUserCommand>()
                .ForMember(CreateUserCommand => CreateUserCommand.Email,
                    opt => opt.MapFrom(RegisterViewModel => RegisterViewModel.Email))
                .ForMember(CreateUserCommand => CreateUserCommand.Organization,
                    opt => opt.MapFrom(RegisterViewModel => RegisterViewModel.Organization))
                .ForMember(CreateUserCommand => CreateUserCommand.ContactPerson,
                    opt => opt.MapFrom(RegisterViewModel => RegisterViewModel.ContactPerson))
                .ForMember(CreateUserCommand => CreateUserCommand.Phone,
                    opt => opt.MapFrom(RegisterViewModel => RegisterViewModel.Phone))
                .ReverseMap();
        }
    }
}
