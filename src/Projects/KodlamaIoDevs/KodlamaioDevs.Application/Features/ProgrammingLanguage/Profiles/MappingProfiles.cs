using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KodlamaioDevs.Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage;
using KodlamaioDevs.Application.Features.ProgrammingLanguage.Dtos;

namespace KodlamaioDevs.Application.Features.ProgrammingLanguage.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.ProgrammingLanguage,CreateProgrammingLanguageDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguage,CreateProgrammingLanguageCommand>().ReverseMap();

        }
    }
}
