using BionicHillbilly.BookShopService.Database.Seed;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BionicHillbilly.BookShopService.Api
{
    /// <summary>
    /// Exposes the application entrypoint
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// This method is the application entrypoint.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.SeedDatabase();
            host.Run();
        }

        /// <summary>
        /// Creates the web host.
        /// </summary>
        /// <param name="args">The application arguments</param>
        /// <returns>The application initialization builder</returns>
        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
