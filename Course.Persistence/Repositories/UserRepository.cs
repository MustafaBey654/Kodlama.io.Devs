

using Core.Persistence.Repositories;
using Core.Security.Entities;
using Course.Application.Service.Repositories;
using Course.Persistence.Contexts;

namespace Course.Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, BaseDbContext>, IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
