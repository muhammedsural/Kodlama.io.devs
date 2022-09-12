using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.JWT;
using KodlamaioDevs.Application.Features.Developers.Commands.CreateDeveloper;
using KodlamaioDevs.Application.Features.Developers.Dtos;
using KodlamaioDevs.Domain.Entities;

namespace KodlamaioDevs.Application.Features.Developers.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Developer, CreateDeveloperCommand>().ReverseMap();
            CreateMap<TokenDto, AccessToken>().ReverseMap();
        }
    }
}
