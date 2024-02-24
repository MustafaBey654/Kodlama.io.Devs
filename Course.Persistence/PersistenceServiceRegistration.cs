using Course.Application.Service.Repositories;
using Course.Persistence.Contexts;
using Course.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Course.Persistence
{    

    public static class PersistenceServiceRegistration
    {
         public static string  LanguageConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CourseLanguageDb; TrustServerCertificate=True;Trusted_Connection=True;";
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<BaseDbContext>(options =>
                       options.UseSqlServer(LanguageConnectionString));
                            //GetConnectionString("LanguageConnectionString")));




            services.AddScoped<ILanguageRepository, LanguageRepository>();

            return services;

        }
    }
}
