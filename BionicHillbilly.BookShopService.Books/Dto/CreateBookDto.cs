namespace BionicHillbilly.BookShopService.Books.Dto
{
    /// <summary>
    /// Data representation to create a book
    /// </summary>
    public class CreateBookDto
    {
        /// <summary>
        /// The title of the book
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// The author of the book
        /// </summary>
        public string Author { get; set; }
        
        /// <summary>
        /// The category of the book
        /// </summary>
        public string Category { get; set; }
    }
}