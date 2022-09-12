using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Paging;
using KodlamaioDevs.Application.Features.GitHubProfiles.Dtos;

namespace KodlamaioDevs.Application.Features.GitHubProfiles.Models
{
    public class GitHubProfileListModel: BasePageableModel
    {
        public IList<GitHubProfileListDto> Items { get; set; }
    }
}
