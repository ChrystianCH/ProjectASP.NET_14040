using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ProjectASP.NET_14040.Models
{
    public class ApplicationUser: IdentityUser
    {
            
        [Display(Name = "Full name")]
        public string FullName { get; set; }
    }

}
