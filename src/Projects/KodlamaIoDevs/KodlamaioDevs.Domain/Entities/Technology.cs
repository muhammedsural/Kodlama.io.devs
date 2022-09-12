﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace KodlamaioDevs.Domain.Entities
{
    public class Technology : Entity
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }

        public Technology()
        {
            
        }

        public Technology(int id ,string name,int programmingLanguageId) : this()
        {
            Id = id;
            Name = name;
            ProgrammingLanguageId = programmingLanguageId;
        }
    }
}
