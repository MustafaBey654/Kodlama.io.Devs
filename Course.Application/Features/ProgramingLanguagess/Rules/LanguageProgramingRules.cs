using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Course.Application.Service.Repositories;
using Course.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Application.Features.ProgramingLanguagess.Rules
{
    public class LanguageProgramingRules
    {
        private readonly ILanguageProgramingRepository _languageProgramingRepository;

        public LanguageProgramingRules(ILanguageProgramingRepository languageProgramingRepository)
        {
            _languageProgramingRepository = languageProgramingRepository;
        }

        public async Task SomeFeatureEntityNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgramingLanguages> result = await _languageProgramingRepository.GetListAsync(x => x.Name == name);

            if (result.Items.Any()) throw new BusinessException("Programming language technology name exist");
        }

        public async Task SomeFeatureEntityNameCanNotBeDuplicatedWhenUpdated(int id, string name)
        {
            IPaginate<ProgramingLanguages> result = await _languageProgramingRepository.GetListAsync(x => x.Id != id && x.Name == name);

            if (result.Items.Any()) throw new BusinessException("Programming language technology name exist");
        }
        public void ProgrammingLanguageTechnologyShouldExistWhenRequested(ProgramingLanguages programmingLanguageTechnology)
        {
            if (programmingLanguageTechnology == null) throw new BusinessException("Requested programming language technology does not exist.");
        }

    }
}
