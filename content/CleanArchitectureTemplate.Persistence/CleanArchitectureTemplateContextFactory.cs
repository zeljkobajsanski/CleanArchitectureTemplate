using CleanArchitectureTemplate.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Persistence
{
    public class CleanArchitectureTemplateContextFactory : DesignTimeDbContextFactoryBase<CleanArchitectureTemplateDbContext>
    {
        protected override CleanArchitectureTemplateDbContext CreateNewInstance(DbContextOptions<CleanArchitectureTemplateDbContext> options)
        {
            return new CleanArchitectureTemplateDbContext(options);
        }
    }
}