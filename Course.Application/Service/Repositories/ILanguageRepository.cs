using Core.Persistence.Repositories;
using Course.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Application.Service.Repositories
{
    public interface ILanguageRepository:IAsyncRepository<Language>,IRepository<Language>
    {
        // Language için özel operasyonlar olursa eklenecek
    }
}
