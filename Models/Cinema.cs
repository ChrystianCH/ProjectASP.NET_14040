using System.ComponentModel.DataAnnotations;

namespace ProjectASP.NET_14040.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }


        public string CinemaLogo { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }

    }
}
