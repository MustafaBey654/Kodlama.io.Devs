using Core.Persistence.Repositories;
using Course.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Application.Service.Repositories
{
    public interface ILanguageProgramingRepository : IAsyncRepository<ProgramingLanguages>, IRepository<ProgramingLanguages>
    {
    }
}
