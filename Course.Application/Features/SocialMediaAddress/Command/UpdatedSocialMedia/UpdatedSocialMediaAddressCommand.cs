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

namespace Course.Application.Features.SocialMediaAddress.Command.UpdatedSocialMedia
{
    public class UpdatedSocialMediaAddressCommand : IRequest<UpdatedSocialMediaDto>
    {
        public int Id { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaUrl { get; set; }
        public int UserId { get; set; }


        public class UpdatedSocialMediaAddressCommandHandler : IRequestHandler<UpdatedSocialMediaAddressCommand, UpdatedSocialMediaDto>
        {
            private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;
            private readonly SocialMediaAddresBusinesRules _socialMediaAddresBusinesRules;

            public UpdatedSocialMediaAddressCommandHandler(ISocialMediaAddressRepository socialMediaAddressRepository, IMapper mapper, SocialMediaAddresBusinesRules socialMediaAddresBusinesRules)
            {
                _socialMediaAddressRepository = socialMediaAddressRepository;
                _mapper = mapper;
                _socialMediaAddresBusinesRules = socialMediaAddresBusinesRules;
            }

            public async Task<UpdatedSocialMediaDto> Handle(UpdatedSocialMediaAddressCommand request, CancellationToken cancellationToken)
            {
                await _socialMediaAddresBusinesRules.SocialMediaAddressNameCanNotBeDuplicatedWhenUpdated(request.Id, request.SocialMediaName);

                SocialMediaAddres mappedMediaAddress = _mapper.Map<SocialMediaAddres>(request);

                SocialMediaAddres updatedMediaAddress = await _socialMediaAddressRepository.UpdateAsync(mappedMediaAddress);

                UpdatedSocialMediaDto updatedSocialMediaDto = _mapper.Map<UpdatedSocialMediaDto>(updatedMediaAddress);
                return updatedSocialMediaDto;
            }
        }

    }
}
