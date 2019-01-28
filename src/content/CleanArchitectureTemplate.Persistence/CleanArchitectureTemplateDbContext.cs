using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Persistence
{
    public class CleanArchitectureTemplateDbContext : DbContext
    {
        public CleanArchitectureTemplateDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}