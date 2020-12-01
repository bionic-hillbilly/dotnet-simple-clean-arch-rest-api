using System.Collections.Generic;
using System.Threading.Tasks;
using BionicHillbilly.BookShopService.Books.Dto;
using BionicHillbilly.BookShopService.Domain;

namespace BionicHillbilly.BookShopService.Books.Repositories
{
    /// <summary>
    /// Provides data access
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Get books with paging
        /// </summary>
        /// <param name="offset">The paging offset</param>
        /// <param name="limit">The paging limit</param>
        /// <returns>A list of books</returns>
        Task<List<Book>> GetBooks(int offset = 0, int limit = 25);

        /// <summary>
        /// Gets a book by its id
        /// </summary>
        /// <param name="id">The identifier of the book</param>
        /// <returns>The found book</returns>
        Task<Book> GetBookById(int id);

        /// <summary>
        /// Creates a book
        /// </summary>
        /// <param name="createBookDto">book to be created</param>
        /// <returns>The created book</returns>
        Task<Book> CreateBook(CreateBookDto bookToCreate);

        /// <summary>
        /// Updates a book
        /// </summary>
        /// <param name="id">The identifier of the book</param>
        /// <param name="updateBookDto">The data to update</param>
        /// <returns>The updated book</returns>
        Task<Book> UpdateBook(int id, UpdateBookDto bookToUpdate);

        /// <summary>
        /// Removes a book
        /// </summary>
        /// <param name="id">The identifier of the book to delete</param>
        /// <returns>The task of the operation</returns>
        Task RemoveBook(int id);
    }
}