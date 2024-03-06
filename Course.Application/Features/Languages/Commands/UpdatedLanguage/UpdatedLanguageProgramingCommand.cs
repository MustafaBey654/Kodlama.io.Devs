using AutoMapper;
using Course.Application.Features.Languages.Dtos;
using Course.Application.Features.Languages.Rules;
using Course.Application.Service.Repositories;
using Course.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Application.Features.Languages.Commands.UpdatedLanguage
{
    public class UpdatedLanguageProgramingCommand:IRequest<UpdatedLanguageProgramingDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExperienceDate { get; set; }


        public class UpdatedLanguageProgramingCommandHandler : IRequestHandler<UpdatedLanguageProgramingCommand, UpdatedLanguageProgramingDto>
        {

            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public UpdatedLanguageProgramingCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
                _languageBusinessRules = languageBusinessRules;
            }

            public async Task<UpdatedLanguageProgramingDto> Handle(UpdatedLanguageProgramingCommand request, CancellationToken cancellationToken)
            {
                await _languageBusinessRules.SomeFeatureEntityNameCanNotBeDuplicatedWhenUpdated(request.Id, request.Name);

                Language mappedLanguage = _mapper.Map<Language>(request);
                Language updatedLanguage = await _languageRepository.UpdateAsync(mappedLanguage);
                UpdatedLanguageProgramingDto updatedLanguageProgramingDto = _mapper.Map<UpdatedLanguageProgramingDto>(updatedLanguage);

                return updatedLanguageProgramingDto;
            }
        }

    }
}
