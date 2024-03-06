

using Core.Persistence.Repositories;
using Course.Application.Service.Repositories;
using Course.Domain.Entities;
using Course.Persistence.Contexts;

namespace Course.Persistence.Repositories
{
    public class LanguageProgramingRepository : EfRepositoryBase<ProgramingLanguages, BaseDbContext>, ILanguageProgramingRepository
    {
        public LanguageProgramingRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
