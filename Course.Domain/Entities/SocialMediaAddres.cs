using Core.Persistence.Repositories;
using Core.Security.Entities;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Domain.Entities
{
    public class SocialMediaAddres:Entity
    {
        public string SocialMediaName { get; set; }
        public string SocialMediaUrl { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }


        public SocialMediaAddres()
        {
            
        }

        public SocialMediaAddres(int id,string socialMediaName, string socialMediaUrl, int userId)
        {
            SocialMediaName = socialMediaName;
            SocialMediaUrl = socialMediaUrl;
            UserId = userId;
            Id = id;
        }
    }
}
