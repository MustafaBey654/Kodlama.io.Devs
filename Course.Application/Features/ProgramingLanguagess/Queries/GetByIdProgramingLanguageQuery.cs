using AutoMapper;
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

namespace Course.Application.Features.ProgramingLanguagess.Queries
{
    public class GetByIdProgramingLanguageQuery:IRequest<GetByIdLanguageProgramingDto>
    {
        public int Id { get; set; }

        public class GetByIdProgramingLanguageQueryHandler : IRequestHandler<GetByIdProgramingLanguageQuery, GetByIdLanguageProgramingDto>
        {
            private readonly ILanguageProgramingRepository _languageProgramingRepository;
            private readonly IMapper _mapper;
            private readonly LanguageProgramingRules _languageProgramingRules;

            public GetByIdProgramingLanguageQueryHandler(ILanguageProgramingRepository languageProgramingRepository, IMapper mapper, LanguageProgramingRules languageProgramingRules)
            {
                _languageProgramingRepository = languageProgramingRepository;
                _mapper = mapper;
                _languageProgramingRules = languageProgramingRules;
            }

            public async Task<GetByIdLanguageProgramingDto> Handle(GetByIdProgramingLanguageQuery request, CancellationToken cancellationToken)
            {
                ProgramingLanguages? programingLanguages =
                  await _languageProgramingRepository.GetAsync(x => x.Id == request.Id,
                    a => a.Include(p => p.language));

                _languageProgramingRules.ProgrammingLanguageTechnologyShouldExistWhenRequested(programingLanguages);


                GetByIdLanguageProgramingDto mappedLanguage = 
                    _mapper.Map<GetByIdLanguageProgramingDto>(programingLanguages);
            
            
                return mappedLanguage;
            }
        }
    }
}
