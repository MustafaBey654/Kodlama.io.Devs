using Core.Persistence.Paging;
using Course.Application.Features.SocialMediaAddress.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Application.Features.SocialMediaAddress.Models
{
    public class ListModelSocialMediaAddress:BasePageableModel
    {
        public IList<ListSocialMediaDto>  Items { get; set; }
    }
}
