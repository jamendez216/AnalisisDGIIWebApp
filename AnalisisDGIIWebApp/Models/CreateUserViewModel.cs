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
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Userame value must be between 10 and 100 characters")]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string EMail { get; set; }
        [Required]
        [DisplayName("Contraseña")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Confirmar Contraseña")]
        [Compare("Password", ErrorMessage ="La contraseña no coincide.")]
        public string ConfirmPassword { get; set; }
    }
}