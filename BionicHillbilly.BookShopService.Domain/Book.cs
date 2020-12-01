namespace BionicHillbilly.BookShopService.Domain
{
    /// <summary>
    /// Data representation of a book
    /// </summary>
    public class Book
    {
        /// <summary>
        /// The identifier of the book
        /// </summary>
        public int BookId { get; set; }
        
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
