using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ProjectASP.NET_14040.Models
{
    /// <summary>
    /// klucz AppliactionUser dziedzicząca z IdentityUser nadaje mu klucz głowny 
    /// </summary>
    public class ApplicationUser: IdentityUser
    {
            
        [Display(Name = "Full name")]
        public string FullName { get; set; }
    }

}
