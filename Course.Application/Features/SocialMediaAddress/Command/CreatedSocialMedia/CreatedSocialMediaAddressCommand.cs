using AutoMapper;
using Course.Application.Features.SocialMediaAddress.Dtos;
using Course.Application.Features.SocialMediaAddress.Rules;
using Course.Application.Service.Repositories;
using Course.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Application.Features.SocialMediaAddress.Command.CreatedSocialMedia
{
    public class CreatedSocialMediaAddressCommand:IRequest<CreatedSocialMediaDto>
    {
        public string SocialMediaName { get; set; }
        public string SocialMediaUrl { get; set; }
        public int UserId { get; set; }

        public class CreatedSocialMediaAddressCommandHandler : IRequestHandler<CreatedSocialMediaAddressCommand, CreatedSocialMediaDto>
        {
            private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;
            private readonly SocialMediaAddresBusinesRules _socialMediaAddresBusinesRules;

            public CreatedSocialMediaAddressCommandHandler(ISocialMediaAddressRepository socialMediaAddressRepository, IMapper mapper, SocialMediaAddresBusinesRules socialMediaAddresBusinesRules)
            {
                _socialMediaAddressRepository = socialMediaAddressRepository;
                _mapper = mapper;
                _socialMediaAddresBusinesRules = socialMediaAddresBusinesRules;
            }

            public async Task<CreatedSocialMediaDto> Handle(CreatedSocialMediaAddressCommand request, CancellationToken cancellationToken)
            {
                await _socialMediaAddresBusinesRules.SocialMediaNameCanNotBeDuplicatedWhenInserted(request.SocialMediaName);

                SocialMediaAddres mappedMediaAddress = _mapper.Map<SocialMediaAddres>(request);
                SocialMediaAddres socialMedia = await _socialMediaAddressRepository.AddAsync(mappedMediaAddress);
                CreatedSocialMediaDto createdSocialMediaDto = _mapper.Map<CreatedSocialMediaDto>(socialMedia);
                return createdSocialMediaDto;
            }
        }
    }
}
