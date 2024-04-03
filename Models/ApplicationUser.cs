using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace pandafilm.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}