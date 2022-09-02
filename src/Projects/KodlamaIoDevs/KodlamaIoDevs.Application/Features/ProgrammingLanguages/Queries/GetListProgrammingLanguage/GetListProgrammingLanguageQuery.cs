using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Models;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;
using MediatR;

namespace KodlamaioDevs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
    public class GetListProgrammingLanguageQuery : IRequest<ProgrammingLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQuery, ProgrammingLanguageListModel>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;

            public GetListProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguage> progLanguages = await _programmingLanguageRepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize);

                ProgrammingLanguageListModel mappedProgLanguageListModel = _mapper.Map<ProgrammingLanguageListModel>(progLanguages);
                return mappedProgLanguageListModel;
            }
        }
    }
}
