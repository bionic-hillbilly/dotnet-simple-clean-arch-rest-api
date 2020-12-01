using BionicHillbilly.BookShopService.Domain;
using Microsoft.EntityFrameworkCore;

namespace BionicHillbilly.BookShopService.Database
{
    /// <summary>
    /// Defines how to access to database
    /// </summary>
    public class BookShopContext : DbContext
    {
        /// <summary>
        /// Books table representation
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// BookShopContext constructor
        /// </summary>
        /// <param name="options">Database context options</param>
        public BookShopContext(DbContextOptions<BookShopContext> options)
            : base(options)
        {
        }
    }
}
