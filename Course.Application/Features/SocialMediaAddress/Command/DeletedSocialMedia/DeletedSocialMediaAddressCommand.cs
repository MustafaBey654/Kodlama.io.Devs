using AutoMapper;
using Course.Application.Features.SocialMediaAddress.Dtos;
using Course.Application.Features.SocialMediaAddress.Rules;
using Course.Application.Service.Repositories;
using MediatR;


namespace Course.Application.Features.SocialMediaAddress.Command.DeletedSocialMedia
{
    public class DeletedSocialMediaAddressCommand : IRequest<DeletedSocialMediDto>
    {
        public int Id { get; set; }

        public class DeletedSocialMediaAddressCommandHandler : IRequestHandler<DeletedSocialMediaAddressCommand, DeletedSocialMediDto>
        {

            private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;
            private readonly SocialMediaAddresBusinesRules _socialMediaAddresBusinesRules;

            public DeletedSocialMediaAddressCommandHandler(ISocialMediaAddressRepository socialMediaAddressRepository, IMapper mapper, SocialMediaAddresBusinesRules socialMediaAddresBusinesRules)
            {
                _socialMediaAddressRepository = socialMediaAddressRepository;
                _mapper = mapper;
                _socialMediaAddresBusinesRules = socialMediaAddresBusinesRules;
            }

            public async Task<DeletedSocialMediDto> Handle(DeletedSocialMediaAddressCommand request, CancellationToken cancellationToken)
            {
                var deletedSocialMedia = await _socialMediaAddressRepository.GetAsync(x => x.Id == request.Id);

                _socialMediaAddresBusinesRules.SocialMediaAddressExistWhenRequested(deletedSocialMedia);
                var result = _socialMediaAddressRepository.Delete(deletedSocialMedia);
                DeletedSocialMediDto response = _mapper.Map<DeletedSocialMediDto>(result);
                return response;
            }
        }
    }
}
