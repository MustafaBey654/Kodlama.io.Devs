using AutoMapper;
using Course.Application.Features.SocialMediaAddress.Dtos;
using Course.Application.Features.SocialMediaAddress.Rules;
using Course.Application.Service.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Application.Features.SocialMediaAddress.Command.ListSocialMedia
{
    public class SocialMediaAddressListCommand : IRequest<ListSocialMediaDto>
    {
        public int Id { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaUrl { get; set; }
        public string UserMail { get; set; }

        public class SocialMediaAddressListCommandHandler : IRequestHandler<SocialMediaAddressListCommand, ListSocialMediaDto>
        {
            private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;
            private readonly SocialMediaAddresBusinesRules _socialMediaAddresBusinesRules;

            public SocialMediaAddressListCommandHandler(ISocialMediaAddressRepository socialMediaAddressRepository, IMapper mapper, SocialMediaAddresBusinesRules socialMediaAddresBusinesRules)
            {
                _socialMediaAddressRepository = socialMediaAddressRepository;
                _mapper = mapper;
                _socialMediaAddresBusinesRules = socialMediaAddresBusinesRules;
            }

            public async Task<ListSocialMediaDto> Handle(SocialMediaAddressListCommand request, CancellationToken cancellationToken)
            {
                var listsocialMedia = await _socialMediaAddressRepository.GetListAsync();

                ListSocialMediaDto listSocialMediaDto = _mapper.Map<ListSocialMediaDto>(listsocialMedia);
                return listSocialMediaDto;
            }
        }
    }
}
