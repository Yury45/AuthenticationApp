using AuthenticationApp.Models;
using AuthenticationApp.ViewModels;
using AutoMapper;

namespace AuthenticationApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, UserViewModel>()
                .ConstructUsing(v => new UserViewModel(v));
        }
    }
}
