using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AnalisisDGIIWebApp.Models
{
    public class LoginRequest
    {
        [DisplayName("Email")]
        public string email { get; set; }

        [DisplayName("Password")]
        public string password { get; set; }
    }
}