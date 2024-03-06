using Core.Persistence.Paging;
using Course.Application.Features.ProgramingLanguagess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Application.Features.ProgramingLanguagess.Models
{
    public class ListModelProgramingLanguage:BasePageableModel
    {
        public IList<ListLanguageProgramingDto>? Items { get; set; }
    }
}
