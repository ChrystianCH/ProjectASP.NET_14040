using System.ComponentModel.DataAnnotations;

namespace ProjectASP.NET_14040.Models
{
    public class BookStore
    {
        [Key]
        public int Id { get; set; }


        public string BookStoreLogo { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }

        //Relations
        public List<BookStore_Book> BookStore_Books { get; set; }
    }
}
