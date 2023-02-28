using api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace api.Extensions.BuilderConfiguration
{
    public static class Database
    {
        public static IServiceCollection SetupDatabase(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            string? dbConnectionString = Environment.GetEnvironmentVariable(EnvironmentVariables.DB_CONNECTION_STRING);
            if (dbConnectionString == null) throw new NullReferenceException(nameof(dbConnectionString));

            services.AddDbContext<DataContext>(options => options.UseSqlServer(dbConnectionString));

            return services;

        }
    }
}
