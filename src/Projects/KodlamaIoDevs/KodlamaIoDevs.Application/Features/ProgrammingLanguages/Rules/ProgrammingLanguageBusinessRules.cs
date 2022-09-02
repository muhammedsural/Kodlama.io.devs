using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using KodlamaioDevs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                throw new BusinessException("Aynı isimde programlama dili eklenemez");
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
