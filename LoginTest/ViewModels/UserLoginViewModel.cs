using Microsoft.AspNetCore.Http.Features;
using System.ComponentModel.DataAnnotations;

namespace LoginTest.ViewModels
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage ="Email cannot be empty")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Must be at least 4 characters long.")]
        public string Pass { get; set; }
    }
}
