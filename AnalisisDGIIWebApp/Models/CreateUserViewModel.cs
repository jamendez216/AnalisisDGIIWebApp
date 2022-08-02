using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnalisisDGIIWebApp.Models
{
    public class CreateUserViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Username value must be between 6 and 100 characters")]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string EMail { get; set; }
        [Required]
        [DisplayName("Contraseña")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Password value must be between 4 and 100 characters")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Confirmar Contraseña")]
        [Compare("Password", ErrorMessage ="La contraseña no coincide.")]
        public string ConfirmPassword { get; set; }
    }
}