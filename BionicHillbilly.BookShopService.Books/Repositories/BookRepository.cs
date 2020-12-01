using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BionicHillbilly.BookShopService.Books.Dto;
using BionicHillbilly.BookShopService.Database;
using BionicHillbilly.BookShopService.Domain;
using Microsoft.EntityFrameworkCore;

[assembly: InternalsVisibleTo("BionicHillbilly.BookShopService.Books.Tests")]
namespace BionicHillbilly.BookShopService.Books.Repositories
{
    /// <inheritdoc />
    internal class BookRepository : IBookRepository
    {
        private readonly BookShopContext _context;

        /// <summary>
        /// BookRepository constructor
        /// </summary>
        public BookRepository(BookShopContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public Task<List<Book>> GetBooks(int offset = 0, int limit = 25)
        {
            return _context.Books.OrderBy(x => x.BookId).Skip(offset * limit).Take(limit).AsNoTracking().ToListAsync();
        }

        /// <inheritdoc />
        public Task<Book> GetBookById(int id)
        {
            return _context.Books.FirstOrDefaultAsync(x => x.BookId.Equals(id));
        }

        /// <inheritdoc />
        public async Task<Book> CreateBook(CreateBookDto bookToCreate)
        {
            var book = new Book
            {
                Title = bookToCreate.Title,
                Author = bookToCreate.Author,
                Category = bookToCreate.Category
            };

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book;
        }

        /// <inheritdoc />
        public async Task<Book> UpdateBook(int id, UpdateBookDto bookToUpdate)
        {
            var foundBook = await GetBookById(id);
            foundBook.Title = bookToUpdate.Title;
            foundBook.Author = bookToUpdate.Author;
            foundBook.Category = bookToUpdate.Category;

            await _context.SaveChangesAsync();

            return foundBook;
        }

        /// <inheritdoc />
        public async Task RemoveBook(int id)
        {
            var foundBook = await GetBookById(id);

            _context.Books.Remove(foundBook);

            await _context.SaveChangesAsync();
        }
    }
}