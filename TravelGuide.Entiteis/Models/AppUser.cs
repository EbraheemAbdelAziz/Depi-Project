using Microsoft.AspNetCore.Identity;

namespace TravelGuide.Entiteis.Models
{
    public class AppUser : IdentityUser
    {
        public string? Address { get; set; }
    }
}
