
using Core.Persistence.Repositories;
using Course.Application.Service.Repositories;
using Course.Domain.Entities;
using Course.Persistence.Contexts;

namespace Course.Persistence.Repositories
{
    public class SocialMediaAddressRepository : EfRepositoryBase<SocialMediaAddres, BaseDbContext>, ISocialMediaAddressRepository
    {
        public SocialMediaAddressRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
