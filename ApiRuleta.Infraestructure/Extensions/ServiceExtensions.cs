using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ApiRuleta.Core.Interfaces.Repositories;
using ApiRuleta.Infraestructure.Data.EntityFrameworkPostgreSQL;

namespace ApiRuleta.Infraestructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureMyPostgreSQLContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<RepositoryContextPostgresql>(
                   options => options.UseNpgsql(config.GetConnectionString("PostgreSqlDBContext"), npgsqlOptions => {
                       npgsqlOptions.CommandTimeout(60);
                   })
               );
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
