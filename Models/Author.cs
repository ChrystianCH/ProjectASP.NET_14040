using System.ComponentModel.DataAnnotations;

namespace ProjectASP.NET_14040.Models
{

    /// <summary>
    /// klasa Author
    /// </summary>
    public class Author
    {
        [Key]
        /// <summary>
        /// Id jako klucz podstawowy dla tabeli Author
        /// </summary>
        public int? Id { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePicture { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Bio")]
        public string Bio { get; set; }
       //Relacje 
        /// <summary>
        ///Relacja jeden do wielu jeden author może mieć wiele książek         /// </summary>
        /// </summary>
        public List<Book>? Books { get; set; }
    }
}
