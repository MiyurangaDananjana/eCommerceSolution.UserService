using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Mappers
{
    public class ApplicationUserMappingProfile : Profile
    {
        public ApplicationUserMappingProfile() 
        {
            CreateMap<ApplicationUser, AuthenticationResponse>()
              .ForMember(destination => destination.UserID, options => options.MapFrom(src => src.UserID))
              .ForMember(destination => destination.Email, options => options.MapFrom(src => src.Email))
              .ForMember(destination => destination.PersonName, options => options.MapFrom(src => src.PersonName))
              .ForMember(destination => destination.Gender, options => options.MapFrom(src => src.Gender))
              .ForMember(destination => destination.Success, options => options.Ignore())
              .ForMember(destination => destination.Token, options => options.Ignore());
        }
    }
}
