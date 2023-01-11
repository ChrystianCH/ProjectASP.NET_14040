using System.ComponentModel.DataAnnotations;

namespace ProjectASP.NET_14040.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }


        public string ProfilePicture { get; set; }

     
        public string FullName { get; set; }

       
        public string Bio { get; set; }

       //Relationships
       public List<Book> Books { get; set; }
    }
}
