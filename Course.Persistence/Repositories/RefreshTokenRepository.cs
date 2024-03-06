

using Core.Persistence.Repositories;
using Core.Security.Entities;
using Course.Application.Service.Repositories;
using Course.Persistence.Contexts;

namespace Course.Persistence.Repositories
{
    public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, BaseDbContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
