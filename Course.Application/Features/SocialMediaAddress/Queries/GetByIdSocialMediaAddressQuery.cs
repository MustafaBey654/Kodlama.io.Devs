using AutoMapper;
using Core.Persistence.Paging;
using Course.Application.Features.ProgramingLanguagess.Dtos;
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

namespace Course.Application.Features.SocialMediaAddress.Queries
{
    public class GetByIdSocialMediaAddressQuery : IRequest<GetByIdSocialMediaDto>
    {
        public int Id { get; set; }

        public class GetByIdSocialMediaAddressQueryHandler : IRequestHandler<GetByIdSocialMediaAddressQuery, GetByIdSocialMediaDto>
        {
            private readonly ISocialMediaAddressRepository _repository;
            private readonly IMapper _mapper;
            private readonly SocialMediaAddresBusinesRules _socialMediaAddresBusinesRules;

            public GetByIdSocialMediaAddressQueryHandler(ISocialMediaAddressRepository repository, IMapper mapper, SocialMediaAddresBusinesRules socialMediaAddresBusinesRules)
            {
                _repository = repository;
                _mapper = mapper;
                _socialMediaAddresBusinesRules = socialMediaAddresBusinesRules;
            }

            public async Task<GetByIdSocialMediaDto> Handle(GetByIdSocialMediaAddressQuery request, CancellationToken cancellationToken)
            {
                SocialMediaAddres? socialMedia = await _repository.GetAsync(l => l.Id == request.Id);
                _socialMediaAddresBusinesRules.SocialMediaAddressExistWhenRequested(socialMedia);

                GetByIdSocialMediaDto getByIdSocialMediaDto = _mapper.Map<GetByIdSocialMediaDto>(socialMedia);
                return getByIdSocialMediaDto;

            }
        }

    }
}
