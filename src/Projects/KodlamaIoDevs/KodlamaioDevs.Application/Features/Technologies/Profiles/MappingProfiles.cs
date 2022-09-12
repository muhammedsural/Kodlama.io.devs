using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Persistence.Paging;
using KodlamaioDevs.Application.Features.Technologies.Commands.CreateTechnology;
using KodlamaioDevs.Application.Features.Technologies.Commands.DeleteTechnology;
using KodlamaioDevs.Application.Features.Technologies.Commands.UpdateTechnology;
using KodlamaioDevs.Application.Features.Technologies.Dtos;
using KodlamaioDevs.Application.Features.Technologies.Models;
using KodlamaioDevs.Domain.Entities;

namespace KodlamaioDevs.Application.Features.Technologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Technology, TechnologyListDto>()
                .ForMember(c => c.ProgrammingLanguageName,
                    opt => opt.MapFrom(c => c.ProgrammingLanguage!.Name)).ReverseMap();

            CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();

            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();
            CreateMap<Technology, CreateTechnologyDto>().ReverseMap();

            CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();
            CreateMap<Technology, UpdateTechnologyDto>().ReverseMap();

            CreateMap<Technology, DeleteTechnologyCommand>().ReverseMap();
            CreateMap<Technology, DeleteTechnologyDto>().ReverseMap();

        }
    }
}
