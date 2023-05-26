using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalCookbook
{
    internal static class Program
    {
        // The main entry point for the application.
        [STAThread]
        static void Main()
        {
            ServiceCollection services = new();
            services.AddDbContext<RecipeContext>();
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                RecipeContext dbContext = serviceProvider.GetRequiredService<RecipeContext>();
                dbContext.Database.Migrate();
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new FormRecipes());
        }
    }
}