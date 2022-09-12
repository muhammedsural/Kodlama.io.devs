using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace KodlamaioDevs.Domain.Entities
{
    public class GitHubProfile : Entity
    {
        public int DeveloperId { get; set; }
        public string ProfileUrl { get; set; }
        public virtual Developer Developer { get; set; }

        public GitHubProfile()
        {

        }

        public GitHubProfile(int id ,int developerId, string profileUrl) : this()
        {
            Id = id;
            DeveloperId = developerId;
            ProfileUrl = profileUrl;

        }
        
    }
}
