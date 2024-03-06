using Core.Persistence.Paging;
using AutoMapper;
using Course.Domain.Entities;
using Course.Application.Features.SocialMediaAddress.Dtos;
using Course.Application.Features.SocialMediaAddress.Command.CreatedSocialMedia;
using Course.Application.Features.SocialMediaAddress.Command.UpdatedSocialMedia;
using Course.Application.Features.SocialMediaAddress.Command.ListSocialMedia;
using Course.Application.Features.SocialMediaAddress.Command.DeletedSocialMedia;

namespace Course.Application.Features.SocialMediaAddress.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SocialMediaAddres, CreatedSocialMediaDto>().ReverseMap();
            CreateMap<SocialMediaAddres, CreatedSocialMediaAddressCommand>().ReverseMap();

            CreateMap<SocialMediaAddres, UpdatedSocialMediaDto>().ReverseMap();
            CreateMap<SocialMediaAddres, UpdatedSocialMediaAddressCommand>().ReverseMap();

            CreateMap<SocialMediaAddres, DeletedSocialMediDto>().ReverseMap();
            CreateMap<SocialMediaAddres, DeletedSocialMediaAddressCommand>().ReverseMap();

            CreateMap<IPaginate<SocialMediaAddres>, ListSocialMediaDto>().ReverseMap();
            CreateMap<SocialMediaAddres, SocialMediaAddressListCommand>()
                .ForMember(c => c.UserMail, opt => opt.MapFrom(c => c.User.Email))
                .ReverseMap();

            CreateMap<SocialMediaAddres, GetByIdSocialMediaDto>()
                .ForMember(c => c.UserMail, opt => opt.MapFrom(c => c.User.Email))
                .ReverseMap();
        }
    }
}
