using AutoMapper;
using KodlamaioDevs.Application.Features.ProgrammingLanguage.Dtos;
using KodlamaioDevs.Application.Services.Repositories;
using MediatR;

namespace KodlamaioDevs.Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommand : IRequest<CreateProgrammingLanguageDto>
    {
        public string Name { get; set; }


    }

    public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand,
            CreateProgrammingLanguageDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        private readonly IMapper _mapper;
        //private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

        public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
        }

        public async Task<CreateProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<Domain.Entities.ProgrammingLanguage>(request);

            Domain.Entities.ProgrammingLanguage createdProgrammingLanguage =
                await _programmingLanguageRepository.AddAsync(mappedProgrammingLanguage);
            CreateProgrammingLanguageDto createProgrammingLanguageDto = _mapper.Map<CreateProgrammingLanguageDto>(createdProgrammingLanguage);

            return createProgrammingLanguageDto;
        }
    }
}

