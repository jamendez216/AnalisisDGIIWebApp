using AnalisisDGII.DL.Data;
using AnalisisDGII.EL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisDGII.BL.Access
{
    public class LoginService
    {
        public UserData DataL = new UserData();

        public bool CreateUser(USER user)
        {
            return DataL.Insert(user);
        }

        public bool EmailExists(string email)
        {
            return DataL.EMailExists(email);
        }

        public bool Login(string email, string password)
        {
            return DataL.Login(email, password);
        }
    }
}
