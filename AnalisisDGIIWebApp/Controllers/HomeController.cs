using AnalisisDGII.BL.Access;
using AnalisisDGII.EL.Database;
using AnalisisDGIIWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnalisisDGIIWebApp.Controllers
{
    public class HomeController : Controller
    {
        LoginService service = new LoginService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session["UserName"] = null;
            return View("Index");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult SignUp(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                string Memail = model.EMail.ToLower();

                if (service.EmailExists(Memail))
                {
                    return View();
                }

                CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);
                var user = new USER()
                {
                    Username = model.Username,
                    EMail = Memail,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
                service.CreateUser(user);
                return View();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginRequest creds)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string Memail = creds.email.ToLower();

                    if (service.EmailExists(Memail))
                    {
                        if (service.Login(Memail, creds.password))
                        {
                            Session["UserName"] = creds.email;
                            return View("Index");
                        }
                    }

                    return View();
                }
                catch (Exception)
                {
                    return View();
                    throw;
                }

            }
            return View();
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}