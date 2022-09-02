using Core.Persistence.Paging;
using KodlamaioDevs.Application.Features.ProgrammingLanguages.Dtos;

namespace KodlamaioDevs.Application.Features.ProgrammingLanguages.Models
{
    public class ProgrammingLanguageListModel : BasePageableModel
    {
        public IList<ProgrammingLanguageListDto> Items { get; set; }
    }
}
