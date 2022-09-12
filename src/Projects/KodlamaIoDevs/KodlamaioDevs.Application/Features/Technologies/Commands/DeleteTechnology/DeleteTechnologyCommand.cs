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

namespace KodlamaioDevs.Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand: IRequest<DeleteTechnologyDto>
    {
        public int Id { get; set; }

        public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeleteTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _technologyRepository;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository,
                IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
                => (_mapper, _technologyRepository, _technologyBusinessRules)
                    = (mapper, technologyRepository, technologyBusinessRules);

            public async Task<DeleteTechnologyDto> Handle(DeleteTechnologyCommand request,
                CancellationToken cancellationToken)
            {
                Technology technology = await _technologyRepository.GetAsync(t => t.Id == request.Id);

                
                _technologyBusinessRules.TechnologyShouldExist(technology);

                Technology deletedTechnology = await _technologyRepository.DeleteAsync(_mapper.Map(request, technology));

                return _mapper.Map<DeleteTechnologyDto>(deletedTechnology);
            }
        }
    }
}
