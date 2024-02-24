using Core.Persistence.Paging;
using Course.Application.Features.Languages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Application.Features.Languages.Models
{
    public class LanguageListModel:BasePageableModel
    {
        public IList<LanguageListDto> Items { get; set; }
    }
}
