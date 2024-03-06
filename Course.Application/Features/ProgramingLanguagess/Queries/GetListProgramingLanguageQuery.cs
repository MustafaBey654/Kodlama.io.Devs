using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Course.Application.Features.ProgramingLanguagess.Models;
using Course.Application.Service.Repositories;
using Course.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Application.Features.ProgramingLanguagess.Queries
{
    public class GetListProgramingLanguageQuery:IRequest<ListModelProgramingLanguage>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProgramingLanguageQueryHandler : IRequestHandler<GetListProgramingLanguageQuery, ListModelProgramingLanguage>
        {
            private readonly ILanguageProgramingRepository _languageProgramingRepository;
            private readonly IMapper _mapper;

            public GetListProgramingLanguageQueryHandler(ILanguageProgramingRepository languageProgramingRepository, IMapper mapper)
            {
                _languageProgramingRepository = languageProgramingRepository;
                _mapper = mapper;
            }

            public async Task<ListModelProgramingLanguage> Handle(GetListProgramingLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgramingLanguages> programingLanguages =
                    await _languageProgramingRepository.GetListAsync(index:request.PageRequest.Page,
                    size:request.PageRequest.PageSize,
                    include:a=>a.Include(p=>p.Language));

                ListModelProgramingLanguage model =
                    _mapper.Map<ListModelProgramingLanguage>(programingLanguages);
                return model;
            }
        }
    }
}
