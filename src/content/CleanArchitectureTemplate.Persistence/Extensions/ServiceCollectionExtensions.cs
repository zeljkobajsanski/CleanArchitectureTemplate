using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureTemplate.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceModule(this IServiceCollection serviceCollection, string connectionString)
        {
            // Add DbContext using SQL Server Provider
            serviceCollection.AddDbContext<CleanArchitectureTemplateDbContext>(options =>
                options.UseSqlServer(connectionString));
            return serviceCollection;
        }
    }
}