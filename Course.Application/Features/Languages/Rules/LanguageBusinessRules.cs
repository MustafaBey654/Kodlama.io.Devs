using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Course.Application.Service.Repositories;
using Course.Domain.Entities;


namespace Course.Application.Features.Languages.Rules
{
    public class LanguageBusinessRules
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageBusinessRules(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Language> result = await _languageRepository.GetListAsync(l => l.Name == name);
            if (result.Items.Any()) throw new BusinessException("Language name exists.");
        }

        public void LanguageShouldExistWhenRequested(Language language)
        {
            if (language == null) throw new BusinessException("Requested Language does not exists.");
        }

        public async Task SomeFeatureEntityNameCanNotBeDuplicatedWhenUpdated(int id, string name)
        {
            IPaginate<Language> result = await _languageRepository.GetListAsync(x => x.Id != id && x.Name == name);

            if (result.Items.Any()) throw new BusinessException("Programming language name exist");
        }
    }
}
