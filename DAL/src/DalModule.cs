using DAL.definition;
using DAL.implementation;
using Microsoft.Extensions.DependencyInjection;

namespace DAL{
    public static class DalModule{
        public static IServiceCollection loadDALModule(this IServiceCollection services)
        {
            return services
                .AddSingleton<IDatabaseConnectionPool, DefaultDatabaseConnectionPool>();
        }
    }
}