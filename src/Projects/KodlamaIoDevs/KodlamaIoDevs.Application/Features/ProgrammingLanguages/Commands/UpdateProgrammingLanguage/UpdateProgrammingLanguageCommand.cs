using AutoMapper;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Dtos;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Rules;
using KodlamaioDevs.Application.Services.Repositories;
using MediatR;
using KodlamaioDevs.Domain.Entities;

namespace KodlamaioDevs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommand : IRequest<UpdateProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdateProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<UpdateProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage mappedprogrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage programmingLanguage = await _programmingLanguageRepository.UpdateAsync(mappedprogrammingLanguage);
                UpdateProgrammingLanguageDto updateProgrammingLanguageDto = _mapper.Map<UpdateProgrammingLanguageDto>(programmingLanguage);

                return updateProgrammingLanguageDto;
                
            }
        }
    }
}
