using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "Username cannot be left blank")]
        [Display(Name="User Name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a valid email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Verify Password")]
        [Compare("Password", ErrorMessage = "Password and Verify Password must match.")]
        public string Verify { get; set; }

        public CreateUserViewModel()
        {

        }

    }
}
