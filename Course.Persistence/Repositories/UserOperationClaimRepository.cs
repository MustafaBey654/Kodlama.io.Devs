


using Core.Persistence.Repositories;
using Core.Security.Entities;
using Course.Application.Service.Repositories;
using Course.Persistence.Contexts;

namespace Course.Persistence.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, BaseDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
