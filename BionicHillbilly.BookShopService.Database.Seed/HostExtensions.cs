using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BionicHillbilly.BookShopService.Database.Seed
{
    public static class HostExtensions
    {
        /// <summary>
        /// Method to seed the database
        /// </summary>
        /// <param name="host"></param>
        public static void SeedDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            Seeder.SeedDatabase(scope.ServiceProvider.GetRequiredService<BookShopContext>());
        }
    }
}
