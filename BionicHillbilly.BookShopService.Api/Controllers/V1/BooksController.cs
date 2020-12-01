using System.Collections.Generic;
using System.Threading.Tasks;
using BionicHillbilly.BookShopService.Books.Dto;
using BionicHillbilly.BookShopService.Books.Services;
using BionicHillbilly.BookShopService.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BionicHillbilly.BookShopService.Api.Controllers.V1
{
    /// <summary>
    /// Exposes http routes in order to manage books
    /// </summary>
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookService _bookService;

        /// <summary>
        /// BooksController constructor
        /// </summary>
        /// <param name="logger">The logger instance</param>
        /// <param name="bookService">The book service instance</param>
        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        /// <summary>
        /// Creates a book
        /// </summary>
        /// <param name="createBookDto">book to be created</param>
        /// <returns>The created book</returns>
        [HttpPost]
        public Task<Book> CreateBook(CreateBookDto createBookDto)
        {
            return _bookService.CreateBook(createBookDto);
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns>Every books</returns>
        [HttpGet]
        public Task<List<Book>> GetBooks()
        {
            return _bookService.GetBooks();
        }

        /// <summary>
        /// Gets a book by its id
        /// </summary>
        /// <param name="id">The identifier of the book</param>
        /// <returns>The found book</returns>
        [HttpGet("{id}")]
        public Task<Book> GetBookById(int id)
        {
            return _bookService.GetBookById(id);
        }

        /// <summary>
        /// Updates a book
        /// </summary>
        /// <param name="id">The identifier of the book</param>
        /// <param name="updateBookDto">The data to update</param>
        /// <returns>The updated book</returns>
        [HttpPut("{id}")]
        public Task<Book> UpdateBook(int id, UpdateBookDto updateBookDto)
        {
            return _bookService.UpdateBook(id, updateBookDto);
        }

        /// <summary>
        /// Removes a book
        /// </summary>
        /// <param name="id">The identifier of the book to delete</param>
        /// <returns>The task of the operation</returns>
        [HttpDelete("{id}")]
        public Task RemoveBook(int id)
        {
            return _bookService.RemoveBook(id);
        }
    }
}