using System.ComponentModel.DataAnnotations;

namespace ProjectASP.NET_14040.Data.ViewModels
{
    public class NewBookVm
    {
        public int Id { get; set; }
        [Display(Name = "Book name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Book description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Book poster URL")]
        [Required(ErrorMessage = "Book poster URL is required")]
        public string Image { get; set; }

        [Display(Name = "Book start date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }


        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Movie category is required")]
        public BookCategory BookCategory { get; set; }

        //Relationships
        [Display(Name = "Select bookstore(s)")]
        [Required(ErrorMessage = "Book bookstore(s) is required")]
        public List<int> BookStoreIds { get; set; }

       

        [Display(Name = "Select a Author")]
        [Required(ErrorMessage = "Book Author is required")]
        public int AuthorId { get; set; }
    }
}
