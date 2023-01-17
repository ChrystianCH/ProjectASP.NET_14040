using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectASP.NET_14040.Data;
namespace ProjectASP.NET_14040.Models
{
    public class Book
    {
        [Key]
        /// <summary>
        /// Id jako klucz podstawowy dla tabeli Author
        /// </summary>
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public DateTime StartDate { get; set; }

        /// <summary>
        /// BookCategory jako enum 
        /// </summary>
        public BookCategory BookCategory { get; set; }

        //Relationsships

        /// <summary>
        /// Tabela pomocniczna do relacji ksiązka - biblioteka jedna ksiązka może mieć wiele bibliotek
        /// </summary>
        public List<BookStore_Book> BookStore_Books { get; set; }

        /// <summary>
        /// Relacja wiele do  jeden ksiązka może mieć wiele autorów i do tego potrzbuje klucza obcego
        /// </summary>
       
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
    }
}
