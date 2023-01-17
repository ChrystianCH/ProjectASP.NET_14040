using System.ComponentModel.DataAnnotations;

namespace ProjectASP.NET_14040.Data.ViewModels
{
    /// <summary>
    /// klasa dla formularza login 
    /// </summary>
    public class LoginVM
    {
       
            [Display(Name = "Email address")]
            [Required(ErrorMessage = "Email address is required")]
            public string EmailAddress { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        
    }
}
