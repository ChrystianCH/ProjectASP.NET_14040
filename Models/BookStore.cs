using System.ComponentModel.DataAnnotations;

namespace ProjectASP.NET_14040.Models
{
    public class BookStore
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Bookstore Logo")]

        public string BookStoreLogo { get; set; }

        [Display(Name = "Name")]

        public string Name { get; set; }

        [Display(Name = "Description")]

        public string Description { get; set; }

        //Relations
        public List<BookStore_Book> BookStore_Books { get; set; }
    }
}
