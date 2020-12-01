using System.Threading.Tasks;
using BionicHillbilly.BookShopService.Books.Dto;
using BionicHillbilly.BookShopService.Books.Repositories;
using BionicHillbilly.BookShopService.Database;
using BionicHillbilly.BookShopService.Database.Seed;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace BionicHillbilly.BookShopService.Books.Tests
{
    /// <summary>
    /// Unit tests for book repository
    /// </summary>
    public class BookRepositoryTest
    {
        private readonly BookShopContext _context;
        private readonly BookRepository _bookRepository;

        /// <summary>
        /// BookRepositoryTest constructor
        /// </summary>
        public BookRepositoryTest()
        {
            var dbOptions = new DbContextOptionsBuilder<BookShopContext>()
                .UseSqlite("Filename=Test.db").Options;
            _context = new BookShopContext(dbOptions);
            _bookRepository = new BookRepository(_context);
        }

        [Fact]
        public async Task Test()
        {
            // arrange
            Seeder.SeedDatabase(_context);
            const int bookId = 1;

            // act
            var result = await _bookRepository.GetBookById(bookId);

            // assert
            result.ShouldNotBeNull();
            result.BookId.ShouldBe(bookId);
            result.Author.ShouldNotBeNull();
            result.Author.ShouldBe("Stephen King");
            result.Title.ShouldNotBeNull();
            result.Title.ShouldBe("Dreamcatcher");
            result.Category.ShouldNotBeNull();
            result.Category.ShouldBe("Science Fiction");
            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Test2()
        {
            // arrange
            Seeder.SeedDatabase(_context);
            var bookToCreate = new CreateBookDto
            {
                Title = "test title",
                Author = "test author",
                Category = "test category"
            };

            // act
            var result = await _bookRepository.CreateBook(bookToCreate);

            // assert
            result.ShouldNotBeNull();
            result.BookId.ShouldBePositive();
            result.Author.ShouldNotBeNull();
            result.Author.ShouldBe(bookToCreate.Author);
            result.Title.ShouldNotBeNull();
            result.Title.ShouldBe(bookToCreate.Title);
            result.Category.ShouldNotBeNull();
            result.Category.ShouldBe(bookToCreate.Category);
            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Test3()
        {
            // arrange
            Seeder.SeedDatabase(_context);
            const int firstBookId = 1;
            var bookToUpdate = new UpdateBookDto()
            {
                Title = "title updated",
                Author = "author updated",
                Category = "category updated"
            };

            // act
            var result = await _bookRepository.UpdateBook(firstBookId, bookToUpdate);

            // assert
            result.ShouldNotBeNull();
            result.BookId.ShouldBe(firstBookId);
            result.Author.ShouldNotBeNull();
            result.Author.ShouldBe(bookToUpdate.Author);
            result.Title.ShouldNotBeNull();
            result.Title.ShouldBe(bookToUpdate.Title);
            result.Category.ShouldNotBeNull();
            result.Category.ShouldBe(bookToUpdate.Category);
            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Test4()
        {
            // arrange
            Seeder.SeedDatabase(_context);
            const int firstBookId = 1;

            // act
            await _bookRepository.RemoveBook(firstBookId);

            // assert
            (await _bookRepository.GetBookById(firstBookId)).ShouldBeNull();
            await _context.Database.EnsureDeletedAsync();
        }

        [Fact]
        public async Task Test5()
        {
            // arrange
            Seeder.SeedDatabase(_context);

            // act
            var result = await _bookRepository.GetBooks(0, 25);

            // assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(2);
            result[0].BookId.ShouldBe(1);
            result[0].Author.ShouldNotBeNull();
            result[0].Author.ShouldBe("Stephen King");
            result[0].Title.ShouldNotBeNull();
            result[0].Title.ShouldBe("Dreamcatcher");
            result[0].Category.ShouldNotBeNull();
            result[0].Category.ShouldBe("Science Fiction");
            result[1].BookId.ShouldBe(2);
            result[1].Author.ShouldNotBeNull();
            result[1].Author.ShouldBe("Stephen King");
            result[1].Title.ShouldNotBeNull();
            result[1].Title.ShouldBe("It");
            result[1].Category.ShouldNotBeNull();
            result[1].Category.ShouldBe("Horror");
            await _context.Database.EnsureDeletedAsync();
        }
    }
}