using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Domain.Entities
{
    public class Language:Entity
    {
        public string Name { get; set; }
        
        public DateTime?  ExperienceDate { get; set; }

        public virtual IList<ProgramingLanguages> ProgramingLanguages { get; set; } 

        public Language()
        {
            
        }

        public Language(int id, string name,DateTime experienceDate):this()
        {
            Id = id;
            Name = name;
            ExperienceDate = experienceDate;
        }
    }
}
