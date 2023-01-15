using System.ComponentModel.DataAnnotations;

namespace ProjectASP.NET_14040.Models
{
    public class Author
    {
        [Key]
        public int? Id { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePicture { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Bio")]
        public string Bio { get; set; }

       //Relationships
       public List<Book>? Books { get; set; }
    }
}
