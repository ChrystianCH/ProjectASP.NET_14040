using System.ComponentModel.DataAnnotations;
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
    }
}
