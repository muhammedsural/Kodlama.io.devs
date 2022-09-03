using AutoMapper;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Constants;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Dtos;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;
using MediatR;

namespace KodlamaioDevs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommand : IRequest<DeleteProgrammingLanguageDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeleteProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;

            public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<DeleteProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage mappedprogrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage programmingLanguage = await _programmingLanguageRepository.DeleteAsync(mappedprogrammingLanguage);
                DeleteProgrammingLanguageDto deleteProgrammingLanguageDto = _mapper.Map<DeleteProgrammingLanguageDto>(programmingLanguage);
                deleteProgrammingLanguageDto.Message =  OperationClaims.ProgrammingLanguageDeleted;

                return deleteProgrammingLanguageDto;
            }
        }
    }
}
