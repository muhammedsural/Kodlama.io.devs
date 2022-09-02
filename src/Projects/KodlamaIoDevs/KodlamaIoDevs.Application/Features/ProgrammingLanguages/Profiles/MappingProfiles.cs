using AutoMapper;
using Core.Persistence.Paging;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Dtos;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Models;
using KodlamaioDevs.Domain.Entities;

namespace KodlamaioDevs.Application.Features.ProgrammingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();

            CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();

            CreateMap<ProgrammingLanguage, ProgrammingLanguageGetByIdDto>().ReverseMap();

            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();

            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();

        }
    }
}
