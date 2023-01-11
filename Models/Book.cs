using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectASP.NET_14040.Data;
namespace ProjectASP.NET_14040.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public DateTime StartDate { get; set; }

        public BookCategory BookCategory { get; set; }
    
      //Relationsships
      
        //BookStore
       public List<BookStore_Book> BookStore_Books { get; set; }
      
        //Author
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
    }
}
