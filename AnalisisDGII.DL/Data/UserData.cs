using AnalisisDGII.DL.Generic;
using AnalisisDGII.EL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisDGII.DL.Data
{
    public class UserData : CRUDModel<USER>, ICRUDModel<USER>
    {
        public bool Login(string email, string password)
        {
            var dbUser = GetAll().FirstOrDefault(x => x.EMail == email);
            if (dbUser != null)
            {
                if (ValidatePassword(password, dbUser.PasswordHash, dbUser.PasswordSalt))
                {
                    return true;
                }
            }
            return false;
        }

        public bool EMailExists(string email)
        {
            var result = GetAll().Any(x => x.EMail == email);
            return GetAll().Any(x => x.EMail == email);
        }


        private bool ValidatePassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var newPasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return new ReadOnlySpan<byte>(passwordHash).SequenceEqual(new ReadOnlySpan<byte>(newPasswordHash));
            }
        }

    }
}
