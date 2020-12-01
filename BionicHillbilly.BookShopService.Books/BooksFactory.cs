using BionicHillbilly.BookShopService.Books.Repositories;
using BionicHillbilly.BookShopService.Books.Services;
using BionicHillbilly.BookShopService.Database;

namespace BionicHillbilly.BookShopService.Books
{
    /// <summary>
    /// Provides creation methods for books features
    /// </summary>
    public static class BooksFactory
    {
        /// <summary>
        /// Creates a business service instance
        /// </summary>
        /// <param name="repository">The repository</param>
        /// <returns>The business service</returns>
        public static IBookService CreateComponent(IBookRepository repository)
        {
            return new BookService(repository);
        }

        /// <summary>
        /// Creates a repository instance
        /// </summary>
        /// <returns>The repository</returns>
        public static IBookRepository CreateRepository(BookShopContext context)
        {
            return new BookRepository(context);
        }
    }
}