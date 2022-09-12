using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Persistence.Paging;
using KodlamaioDevs.Application.Features.GitHubProfiles.Commands.CreateGitHubProfiles;
using KodlamaioDevs.Application.Features.GitHubProfiles.Commands.DeleteGitHubProfiles;
using KodlamaioDevs.Application.Features.GitHubProfiles.Commands.UpdateGitHubProfiles;
using KodlamaioDevs.Application.Features.GitHubProfiles.Dtos;
using KodlamaioDevs.Application.Features.GitHubProfiles.Models;
using KodlamaioDevs.Domain.Entities;

namespace KodlamaioDevs.Application.Features.GitHubProfiles.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<GitHubProfile, CreateGitHubProfileCommand>().ReverseMap();
            CreateMap<GitHubProfile, CreateGitHubProfileDto>().ReverseMap();
        
            CreateMap<GitHubProfile, UpdateGitHubProfileCommand>().ReverseMap();
            CreateMap<GitHubProfile, UpdateGitHubProfileDto>().ReverseMap();

            CreateMap<GitHubProfile, DeleteGitHubProfileCommand>().ReverseMap();
            CreateMap<GitHubProfile, DeleteGitHubProfileDto>().ReverseMap();

            //getlistquery
            CreateMap<GitHubProfileListModel, IPaginate<GitHubProfile>>().ReverseMap();
            CreateMap<GitHubProfile, GitHubProfileListDto>().ReverseMap();
        }
    }
}
