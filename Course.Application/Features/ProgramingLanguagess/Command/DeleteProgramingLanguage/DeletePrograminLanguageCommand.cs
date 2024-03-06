using AutoMapper;
using Course.Application.Features.Languages.Dtos;
using Course.Application.Features.ProgramingLanguagess.Rules;
using Course.Application.Service.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Application.Features.ProgramingLanguagess.Command.DeleteProgramingLanguage
{
    public class DeletePrograminLanguageCommand:IRequest<DeletedLanguageProgramingDto>
    {
        public int Id { get; set; }


        public class DeletePrograminLanguageCommandHandler : IRequestHandler<DeletePrograminLanguageCommand, DeletedLanguageProgramingDto>
        {

            private readonly ILanguageProgramingRepository _languageProgramingRepository;
            private readonly IMapper _mapper;
            private readonly LanguageProgramingRules _languageProgramingRules;

            public DeletePrograminLanguageCommandHandler(ILanguageProgramingRepository languageProgramingRepository, IMapper mapper, LanguageProgramingRules languageProgramingRules)
            {
                _languageProgramingRepository = languageProgramingRepository;
                _mapper = mapper;
                _languageProgramingRules = languageProgramingRules;
            }

            public async Task<DeletedLanguageProgramingDto> Handle(DeletePrograminLanguageCommand request, CancellationToken cancellationToken)
            {
                var deletedLanguagePrograming = await _languageProgramingRepository.GetAsync(x => x.Id == request.Id);

                _languageProgramingRules.ProgrammingLanguageTechnologyShouldExistWhenRequested(deletedLanguagePrograming);

                var result = _languageProgramingRepository.Delete(deletedLanguagePrograming);
                DeletedLanguageProgramingDto response = _mapper.Map<DeletedLanguageProgramingDto>(result);
                return response;

            }
        }

    }
}
