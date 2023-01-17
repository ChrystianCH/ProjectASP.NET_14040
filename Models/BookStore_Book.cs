namespace ProjectASP.NET_14040.Models
{
    public class BookStore_Book
    {

        /// <summary>
        /// Tabela pomocniczna do relacji ksiązka - biblioteka
        /// </summary>
        /// <summary>
        /// klucz obcy dla ksiązki
        /// </summary>
        public int BookId { get; set; }
        public Book Book { get; set; }

        /// <summary>
        /// klucz obcy dla bibliotek
        /// </summary>
        public int BookStoreId { get; set; }
        public BookStore BookStore { get; set; }
    }
}
