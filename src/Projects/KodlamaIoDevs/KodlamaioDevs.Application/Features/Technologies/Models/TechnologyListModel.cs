using KodlamaioDevs.Application.Features.ProgrammingLanguages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodlamaioDevs.Application.Features.Technologies.Dtos;

namespace KodlamaioDevs.Application.Features.Technologies.Models
{
    public class TechnologyListModel
    {
        public IList<TechnologyListDto> Items { get; set; }
    }
}
