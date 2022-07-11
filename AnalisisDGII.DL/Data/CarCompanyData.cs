using AnalisisDGII.DL.Generic;
using AnalisisDGII.EL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisDGII.DL.Data
{
    public class CarCompanyData : CRUDModel<CARCOMPANY>, ICRUDModel<CARCOMPANY>
    {
        public int CreateIfNotExists(string description)
        {
            var carCompany = GetAll().Where(x => x.CarComapanyDescription.ToLower() == description.ToLower()).FirstOrDefault();
            if (carCompany != null)
            {
                return carCompany.CarComapanyID;
            }
            else
            {
                var newCompany = new CARCOMPANY() { CarComapanyDescription = description };
                return AddGetObject(newCompany).CarComapanyID;
            }
        }
    }
}
