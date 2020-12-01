using BionicHillbilly.BookShopService.Books;
using BionicHillbilly.BookShopService.Books.Repositories;
using BionicHillbilly.BookShopService.Database;
using Microsoft.Extensions.DependencyInjection;

namespace BionicHillbilly.BookShopService.Api
{
    /// <summary>
    /// Provides extensions methods
    /// </summary>
    internal static class StartupExtensions
    {
        /// <summary>
        /// Injects books module
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <returns>The updated service collection</returns>
        public static IServiceCollection AddBooks(this IServiceCollection services)
        {
            return services.AddScoped( x => BooksFactory.CreateRepository(x.GetService<BookShopContext>()))
                            .AddScoped(x => BooksFactory.CreateComponent(x.GetService<IBookRepository>()));
        }
    }
}