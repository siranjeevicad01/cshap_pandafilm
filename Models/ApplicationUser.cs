using Microsoft.AspNetCore.Identity;

namespace pandafilm.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Discriminator { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
