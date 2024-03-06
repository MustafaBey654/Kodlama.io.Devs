

using Core.Persistence.Repositories;
using Core.Security.Entities;
using Course.Application.Service.Repositories;
using Course.Persistence.Contexts;

namespace Course.Persistence.Repositories
{
    public class OperationClaimRepository : EfRepositoryBase<OperationClaim, BaseDbContext>, IOperationClaimRepository
    {
        public OperationClaimRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
