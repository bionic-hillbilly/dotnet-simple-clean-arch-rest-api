using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BionicHillbilly.BookShopService.Books.Dto;
using BionicHillbilly.BookShopService.Books.Repositories;
using BionicHillbilly.BookShopService.Domain;

[assembly: InternalsVisibleTo("BionicHillbilly.BookShopService.Books.Tests")]
namespace BionicHillbilly.BookShopService.Books.Services
{
    /// <inheritdoc />
    internal class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        /// <summary>
        /// BookService constructor
        /// </summary>
        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public Task<List<Book>> GetBooks()
        {
            return _repository.GetBooks();
        }

        /// <inheritdoc />
        public Task<Book> GetBookById(int id)
        {
            return _repository.GetBookById(id);
        }

        /// <inheritdoc />
        public Task<Book> CreateBook(CreateBookDto bookToCreate)
        {
            return _repository.CreateBook(bookToCreate);
        }

        /// <inheritdoc />
        public Task<Book> UpdateBook(int id, UpdateBookDto bookToUpdate)
        {
            return _repository.UpdateBook(id, bookToUpdate);
        }

        /// <inheritdoc />
        public Task RemoveBook(int id)
        {
            return _repository.RemoveBook(id);
        }
    }
}
