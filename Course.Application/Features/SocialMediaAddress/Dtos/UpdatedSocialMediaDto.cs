using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Application.Features.SocialMediaAddress.Dtos
{
    public class UpdatedSocialMediaDto
    {
        public int Id { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaUrl { get; set; }
        public int  UserId { get; set; }
    }
}
