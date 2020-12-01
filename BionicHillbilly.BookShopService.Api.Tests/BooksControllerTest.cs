using System.Collections.Generic;
using System.Threading.Tasks;
using BionicHillbilly.BookShopService.Api.Controllers.V1;
using BionicHillbilly.BookShopService.Books.Dto;
using BionicHillbilly.BookShopService.Books.Services;
using BionicHillbilly.BookShopService.Domain;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace BionicHillbilly.BookShopService.Api.Tests
{
    /// <summary>
    /// Unit tests for the books controller
    /// </summary>
    public class BooksControllerTest
    {
        private readonly Mock<IBookService> _mockService;
        private readonly BooksController _controller;

        /// <summary>
        /// BooksControllerTest constructor
        /// </summary>
        public BooksControllerTest()
        {
            var mockLogger = new Mock<ILogger<BooksController>>();
            _mockService = new Mock<IBookService>();
            _mockService.Setup(x => x.CreateBook(It.IsAny<CreateBookDto>()))
                .ReturnsAsync(new Book
                {
                    BookId = 1,
                    Title = "Test book",
                    Author = "John Doe",
                    Category = "Fantasy"
                });
            _mockService.Setup(x => x.GetBooks())
                .ReturnsAsync(new List<Book>()
                {
                    new Book { BookId = 1, Title = "Test book", Author = "John Doe", Category = "Fantasy" },
                    new Book { BookId = 2, Title = "Test book 2", Author = "Jane Doe", Category = "Science Fiction" }
                });
            _mockService.Setup(x => x.GetBookById(It.IsAny<int>()))
                .ReturnsAsync(new Book
                {
                    BookId = 1,
                    Title = "Test book",
                    Author = "John Doe",
                    Category = "Fantasy"
                });
            _mockService.Setup(x => x.UpdateBook(It.IsAny<int>(), It.IsAny<UpdateBookDto>()))
                .ReturnsAsync(new Book
                {
                    BookId = 1,
                    Title = "Updated book",
                    Author = "John Doe",
                    Category = "Fantasy"
                });
            _controller = new BooksController(mockLogger.Object, _mockService.Object);
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
            var result = await _controller.CreateBook(bookCreate);

            // assert
            result.ShouldNotBeNull();
            result.BookId.ShouldBe(1);
            result.Author.ShouldNotBeNull();
            result.Author.ShouldBe(bookCreate.Author);
            result.Title.ShouldNotBeNull();
            result.Title.ShouldBe(bookCreate.Title);
            result.Category.ShouldNotBeNull();
            result.Category.ShouldBe(bookCreate.Category);
            _mockService.Verify(x => x.CreateBook(It.IsAny<CreateBookDto>()), Times.Once());
        }

        [Fact]
        public async Task WhenServiceGetBooks_ThenReturnRecords()
        {
            // act
            var result = await _controller.GetBooks();

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
            _mockService.Verify(x => x.GetBooks(), Times.Once());
        }

        [Fact]
        public async Task GivenValidId_WhenGetBookById_ThenReturnRecord()
        {
            // arrange
            const int bookId = 1;
            // act
            var result = await _controller.GetBookById(bookId);

            // assert
            result.ShouldNotBeNull();
            result.BookId.ShouldBe(1);
            result.Author.ShouldNotBeNull();
            result.Author.ShouldBe("John Doe");
            result.Title.ShouldNotBeNull();
            result.Title.ShouldBe("Test book");
            result.Category.ShouldNotBeNull();
            result.Category.ShouldBe("Fantasy");
            _mockService.Verify(x => x.GetBookById(It.IsAny<int>()), Times.Once());
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
            var result = await _controller.UpdateBook(bookId, updateBook);

            // assert
            result.ShouldNotBeNull();
            result.BookId.ShouldBe(1);
            result.Author.ShouldNotBeNull();
            result.Author.ShouldBe("John Doe");
            result.Title.ShouldNotBeNull();
            result.Title.ShouldBe("Updated book");
            result.Category.ShouldNotBeNull();
            result.Category.ShouldBe("Fantasy");
            _mockService.Verify(x => x.UpdateBook(It.IsAny<int>(),It.IsAny<UpdateBookDto>()), Times.Once());
        }

        [Fact]
        public async Task GivenValidId_WhenRemoveBook_ThenReturnRecord()
        {
            // arrange
            const int bookId = 1;
            // act
            await _controller.RemoveBook(bookId);

            // assert
            _mockService.Verify(x => x.RemoveBook(It.IsAny<int>()), Times.Once());
        }
    }
}
