using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using KodlamaioDevs.Application.Services.Repositories;

namespace KodlamaioDevs.Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Domain.Entities.ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(a => a.Name == name);
            if (result.Items.Any())
            {
                throw new BusinessException("You can not insert same programming language name...");
            }
        }

        public void ProgrammingLanguageShouldExistWhenRequest(Domain.Entities.ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage == null)
            {
                throw new BusinessException("Programming Language does not exist...");
            }
        }


    }
}
