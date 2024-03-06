using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Course.Application.Service.Repositories;
using Course.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Application.Features.SocialMediaAddress.Rules
{
    public class SocialMediaAddresBusinesRules
    {
        private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;

        public SocialMediaAddresBusinesRules(ISocialMediaAddressRepository socialMediaAddressRepository)
        {
            _socialMediaAddressRepository = socialMediaAddressRepository;
        }


        public async Task SocialMediaNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<SocialMediaAddres> result = await _socialMediaAddressRepository.GetListAsync(l => l.SocialMediaName == name);

            if (result.Items.Any()) throw new BusinessException("socialMedia Adress name exists.");

        }

        public void SocialMediaAddressExistWhenRequested(SocialMediaAddres socialMediaAddres)
        {
            if (socialMediaAddres == null) throw new BusinessException("Requested SocialMediaAddress does not exists.");
        }

        public async Task SocialMediaAddressNameCanNotBeDuplicatedWhenUpdated(int id, string socialMediaAddressName)
        {
            IPaginate<SocialMediaAddres> result = await _socialMediaAddressRepository.GetListAsync(x => x.Id != id && x.SocialMediaName == socialMediaAddressName);
            if (result.Items.Any()) throw new BusinessException(" Socail media address name exist");
        }
    }
}

