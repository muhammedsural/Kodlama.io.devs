﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using KodlamaioDevs.Application.Features.GitHubProfiles.Models;
using KodlamaioDevs.Application.Services.Repositories;
using KodlamaioDevs.Domain.Entities;
using MediatR;

namespace KodlamaioDevs.Application.Features.GitHubProfiles.Queries.GetListGitHubProfile
{
    public class GetListGitHubProfileQuery : IRequest<GitHubProfileListModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }

        public string[] Roles { get; } = new string[1] {"admin"};

        public class
            GetListGitHubProfileQueryHandler : IRequestHandler<GetListGitHubProfileQuery, GitHubProfileListModel>
        {
            private readonly IMapper _mapper;
            private readonly IGitHubProfileRepository _gitHubProfileRepository;

            public GetListGitHubProfileQueryHandler(IMapper mapper, IGitHubProfileRepository gitHubProfileRepository)
                => (_mapper, _gitHubProfileRepository) = (mapper, gitHubProfileRepository);

            public async Task<GitHubProfileListModel> Handle(GetListGitHubProfileQuery request,
                CancellationToken cancellationToken)
            {
                IPaginate<GitHubProfile> profiles = await _gitHubProfileRepository
                    .GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                GitHubProfileListModel githubProfileListModel = _mapper.Map<GitHubProfileListModel>(profiles);

                return githubProfileListModel;
            }
        }
    }
}
