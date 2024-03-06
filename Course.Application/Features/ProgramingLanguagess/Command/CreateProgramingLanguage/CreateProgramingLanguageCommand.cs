using AutoMapper;
using Course.Application.Features.Languages.Rules;
using Course.Application.Features.ProgramingLanguagess.Dtos;
using Course.Application.Features.ProgramingLanguagess.Rules;
using Course.Application.Service.Repositories;
using Course.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Application.Features.ProgramingLanguagess.Command.CreateProgramingLanguage
{
    public class CreateProgramingLanguageCommand:IRequest<CreatedProgramingLanguageDto>
    {
        public string Name { get; set; }
        public int LanguageId { get; set; }


        public class CreateProgramingLanguageCommandHandler : IRequestHandler<CreateProgramingLanguageCommand, CreatedProgramingLanguageDto>
        {

            private readonly ILanguageProgramingRepository _languageProgramingRepository;
            private readonly IMapper _mapper;
            private readonly LanguageProgramingRules _languageProgramingRules;

            public CreateProgramingLanguageCommandHandler(ILanguageProgramingRepository languageProgramingRepository, IMapper mapper, LanguageProgramingRules languageProgramingRules)
            {
                _languageProgramingRepository = languageProgramingRepository;
                _mapper = mapper;
                _languageProgramingRules = languageProgramingRules;
            }

            public async Task<CreatedProgramingLanguageDto> Handle(CreateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {

                await _languageProgramingRules.SomeFeatureEntityNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgramingLanguages mappedProgramingLanguage = _mapper.Map<ProgramingLanguages>(request);

                ProgramingLanguages createdProgramingLanguage = await _languageProgramingRepository.AddAsync(mappedProgramingLanguage);

                CreatedProgramingLanguageDto createdDto = _mapper.Map<CreatedProgramingLanguageDto>(createdProgramingLanguage);
                return createdDto;
            }
        }
    }
}
