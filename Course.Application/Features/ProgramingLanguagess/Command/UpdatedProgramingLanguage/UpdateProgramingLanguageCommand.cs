using AutoMapper;
using Course.Application.Features.Languages.Dtos;
using Course.Application.Features.ProgramingLanguagess.Rules;
using Course.Application.Service.Repositories;
using Course.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Application.Features.ProgramingLanguagess.Command.UpdatedProgramingLanguage
{
    public class UpdateProgramingLanguageCommand:IRequest<UpdatedLanguageProgramingDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LanguageId { get; set; }

        public class UpdateProgramingLanguageCommandHandler : IRequestHandler<UpdateProgramingLanguageCommand, UpdatedLanguageProgramingDto>
        {
            private readonly ILanguageProgramingRepository _languageProgramingRepository;
            private readonly IMapper _mapper;
            private readonly LanguageProgramingRules _languageProgramingRules;

            public UpdateProgramingLanguageCommandHandler(ILanguageProgramingRepository languageProgramingRepository, IMapper mapper, LanguageProgramingRules languageProgramingRules)
            {
                _languageProgramingRepository = languageProgramingRepository;
                _mapper = mapper;
                _languageProgramingRules = languageProgramingRules;
            }

            public async Task<UpdatedLanguageProgramingDto> Handle(UpdateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _languageProgramingRules.SomeFeatureEntityNameCanNotBeDuplicatedWhenUpdated(request.Id, request.Name);

                ProgramingLanguages mappedLanguage = _mapper.Map<ProgramingLanguages>(request);

                ProgramingLanguages updatedLanguage = await _languageProgramingRepository.UpdateAsync(mappedLanguage);

                UpdatedLanguageProgramingDto updatedLanguageProgramingDto = _mapper.Map<UpdatedLanguageProgramingDto>(updatedLanguage);
                return updatedLanguageProgramingDto;
            }
        }

    }
}
