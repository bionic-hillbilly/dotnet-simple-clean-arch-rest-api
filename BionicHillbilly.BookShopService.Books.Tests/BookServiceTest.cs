using System.Collections.Generic;
using System.Threading.Tasks;
using BionicHillbilly.BookShopService.Books.Dto;
using BionicHillbilly.BookShopService.Books.Repositories;
using BionicHillbilly.BookShopService.Books.Services;
using BionicHillbilly.BookShopService.Domain;
using Moq;
using Shouldly;
using Xunit;

namespace BionicHillbilly.BookShopService.Books.Tests
{
    /// <summary>
    /// Unit tests for book service
    /// </summary>
    public class BookServiceTest
    {
        private readonly Mock<IBookRepository> _bookRepository;
        private readonly BookService _bookService;

        /// <summary>
        /// BookServiceTest constructor
        /// </summary>
        public BookServiceTest()
        {
            _bookRepository = new Mock<IBookRepository>();
            _bookRepository.Setup(x => x.CreateBook(It.IsAny<CreateBookDto>()))
                .ReturnsAsync(new Book
                {
                    BookId = 1,
                    Title = "Test book",
                    Author = "John Doe",
                    Category = "Fantasy"
                });
            _bookRepository.Setup(x => x.GetBooks(0, 25))
                .ReturnsAsync(new List<Book>()
                {
                    new Book { BookId = 1, Title = "Test book", Author = "John Doe", Category = "Fantasy" },
                    new Book { BookId = 2, Title = "Test book 2", Author = "Jane Doe", Category = "Science Fiction" }
                });
            _bookRepository.Setup(x => x.GetBookById(It.IsAny<int>()))
                .ReturnsAsync(new Book
                {
                    BookId = 1,
                    Title = "Test book",
                    Author = "John Doe",
                    Category = "Fantasy"
                });
            _bookRepository.Setup(x => x.UpdateBook(It.IsAny<int>(), It.IsAny<UpdateBookDto>()))
                .ReturnsAsync(new Book
                {
                    BookId = 1,
                    Title = "Updated book",
                    Author = "John Doe",
                    Category = "Fantasy"
                });
            _bookService = new BookService(_bookRepository.Object);
        }

        [Fact]
        public async Task GivenValidBookCreation_WhenServiceCreateBook_ThenReturnCreatedRecord()
        {
            // arrange
            var bookCreate = new CreateBookDto
            {
                Title = "Test book",
                Author = "John Doe",
                Category = "Fantasy"
            };

            // act
            var result = await _bookService.CreateBook(bookCreate);

            // assert
            result.ShouldNotBeNull();
            result.BookId.ShouldBe(1);
            result.Author.ShouldNotBeNull();
            result.Author.ShouldBe(bookCreate.Author);
            result.Title.ShouldNotBeNull();
            result.Title.ShouldBe(bookCreate.Title);
            result.Category.ShouldNotBeNull();
            result.Category.ShouldBe(bookCreate.Category);
            _bookRepository.Verify(x => x.CreateBook(It.IsAny<CreateBookDto>()), Times.Once());
        }

        [Fact]
        public async Task WhenServiceGetBooks_ThenReturnRecords()
        {
            // act
            var result = await _bookService.GetBooks();

            // assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(2);
            result[0].BookId.ShouldBe(1);
            result[0].Author.ShouldNotBeNull();
            result[0].Author.ShouldBe("John Doe");
            result[0].Title.ShouldNotBeNull();
            result[0].Title.ShouldBe("Test book");
            result[0].Category.ShouldNotBeNull();
            result[0].Category.ShouldBe("Fantasy");
            result[1].BookId.ShouldBe(2);
            result[1].Author.ShouldNotBeNull();
            result[1].Author.ShouldBe("Jane Doe");
            result[1].Title.ShouldNotBeNull();
            result[1].Title.ShouldBe("Test book 2");
            result[1].Category.ShouldNotBeNull();
            result[1].Category.ShouldBe("Science Fiction");
            _bookRepository.Verify(x => x.GetBooks(0, 25), Times.Once());
        }

        [Fact]
        public async Task GivenValidId_WhenGetBookById_ThenReturnRecord()
        {
            // arrange
            const int bookId = 1;
            // act
            var result = await _bookService.GetBookById(bookId);

            // assert
            result.ShouldNotBeNull();
            result.BookId.ShouldBe(1);
            result.Author.ShouldNotBeNull();
            result.Author.ShouldBe("John Doe");
            result.Title.ShouldNotBeNull();
            result.Title.ShouldBe("Test book");
            result.Category.ShouldNotBeNull();
            result.Category.ShouldBe("Fantasy");
            _bookRepository.Verify(x => x.GetBookById(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public async Task GivenValidData_WhenUpdateBook_ThenReturnUpdatedRecord()
        {
            // arrange
            const int bookId = 1;
            var updateBook = new UpdateBookDto
            {
                Title = "Updated book",
                Author = "John Doe",
                Category = "Fantasy"
            };

            // act
            var result = await _bookService.UpdateBook(bookId, updateBook);

            // assert
            result.ShouldNotBeNull();
            result.BookId.ShouldBe(1);
            result.Author.ShouldNotBeNull();
            result.Author.ShouldBe("John Doe");
            result.Title.ShouldNotBeNull();
            result.Title.ShouldBe("Updated book");
            result.Category.ShouldNotBeNull();
            result.Category.ShouldBe("Fantasy");
            _bookRepository.Verify(x => x.UpdateBook(It.IsAny<int>(),It.IsAny<UpdateBookDto>()), Times.Once());
        }

        [Fact]
        public async Task GivenValidId_WhenRemoveBook_ThenReturnRecord()
        {
            // arrange
            const int bookId = 1;
            // act
            await _bookService.RemoveBook(bookId);

            // assert
            _bookRepository.Verify(x => x.RemoveBook(It.IsAny<int>()), Times.Once());
        }
    }
}
