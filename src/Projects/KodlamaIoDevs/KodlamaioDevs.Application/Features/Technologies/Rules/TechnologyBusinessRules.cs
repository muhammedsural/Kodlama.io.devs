using Core.CrossCuttingConcerns.Exceptions;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;

namespace KodlamaioDevs.Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technologyRepository;
        public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
            => _technologyRepository = technologyRepository;

        public void TechnologyShouldExist(Technology technology)
        {
            if (technology == null) throw new BusinessException("This technology doesn't exist");
        }
    }
}
