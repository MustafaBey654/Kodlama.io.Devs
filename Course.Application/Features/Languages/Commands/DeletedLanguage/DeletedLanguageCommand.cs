using AutoMapper;
using Course.Application.Features.Languages.Dtos;
using Course.Application.Features.Languages.Rules;
using Course.Application.Service.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Application.Features.Languages.Commands.DeletedLanguage
{
    public class DeletedLanguageCommand:IRequest<DeletedLanguageProgramingDto>
    {
        public int Id { get; set; }


        public class DeletedLanguageCommandHandler : IRequestHandler<DeletedLanguageCommand, DeletedLanguageProgramingDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public DeletedLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<DeletedLanguageProgramingDto> Handle(DeletedLanguageCommand request, CancellationToken cancellationToken)
            {
                var deletedLanguagePrograming = await _languageRepository.GetAsync(x => x.Id == request.Id);

                _languageBusinessRules.LanguageShouldExistWhenRequested(deletedLanguagePrograming);

                var result = _languageRepository.Delete(deletedLanguagePrograming);
                DeletedLanguageProgramingDto response =
                    _mapper.Map<DeletedLanguageProgramingDto>(result);

                return response;
            }
        }
    }
}
