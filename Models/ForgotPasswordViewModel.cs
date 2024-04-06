using System.ComponentModel.DataAnnotations;

namespace pandafilm.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public string Email { get; set; }
    }
}
