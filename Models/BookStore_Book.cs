namespace ProjectASP.NET_14040.Models
{
    public class BookStore_Book
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int BookStoreId { get; set; }
        public BookStore BookStore { get; set; }
    }
}
