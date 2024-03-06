

using Core.Persistence.Repositories;
using Course.Application.Service.Repositories;
using Course.Domain.Entities;
using Course.Persistence.Contexts;

namespace Course.Persistence.Repositories
{
    public class LanguageRepository : EfRepositoryBase<Language, BaseDbContext>, ILanguageRepository
    {
        public LanguageRepository(BaseDbContext context) : base(context)
        {

        }
    }

}
