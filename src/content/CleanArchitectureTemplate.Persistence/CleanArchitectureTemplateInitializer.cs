namespace CleanArchitectureTemplate.Persistence
{
    public class CleanArchitectureTemplateInitializer
    {
        public static void Initialize(CleanArchitectureTemplateDbContext context)
        {
            var initializer = new CleanArchitectureTemplateInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(CleanArchitectureTemplateDbContext context)
        {
            context.Database.EnsureCreated();

        }
    }
}