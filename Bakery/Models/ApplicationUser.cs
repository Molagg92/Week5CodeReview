using Microsoft.AspNetCore.Identity;

namespace Bakery.Models
{
    public class ApplicationUser : IdentityUser
    {
      public string OrderHistory { get; set; }
    
    }
}