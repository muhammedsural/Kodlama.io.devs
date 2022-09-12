using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KodlamaioDevs.Application.Features.Technologies.Dtos;
using KodlamaioDevs.Application.Features.Technologies.Rules;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;
using MediatR;

namespace KodlamaioDevs.Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommand: IRequest<UpdateTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }

        public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdateTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _technologyRepository;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public UpdateTechnologyCommandHandler(IMapper mapper, ITechnologyRepository technologyRepository,
                TechnologyBusinessRules technologyBusinessRules)
                => (_mapper, _technologyRepository, _technologyBusinessRules)
                    = (mapper, technologyRepository, technologyBusinessRules);

            public async Task<UpdateTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology technology = await _technologyRepository.GetAsync(t => t.Id == request.Id);

                _technologyBusinessRules.TechnologyShouldExist(technology);

                var updatedTechnology = await _technologyRepository.UpdateAsync(_mapper.Map(request, technology!));

                UpdateTechnologyDto updatedTechnologyDto = _mapper.Map<UpdateTechnologyDto>(updatedTechnology);
                return updatedTechnologyDto;
            }
        }
    }
}
