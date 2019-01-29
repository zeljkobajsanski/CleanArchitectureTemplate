using CleanArchitectureTemplate.Common;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureTemplate.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDateTime, MachineDateTime>();
            return serviceCollection;
        }
    }
}