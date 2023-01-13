using System.ComponentModel.DataAnnotations;
namespace ProjectASP.NET_14040.Models
{
    public class BookStore
    {
        [Key]
        public int? Id { get; set; }

        [Display(Name = "Bookstore Logo")]
        [Required(ErrorMessage = "BookStore logo is required")]
        public string BookStoreLogo { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Bookstore name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Bookstore description is required")]
        public string Description { get; set; }

        //Relations
        public List<BookStore_Book>? BookStore_Books { get; set; }
    }
}
