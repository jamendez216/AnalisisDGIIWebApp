using AnalisisDGII.DL.Generic;
using AnalisisDGII.EL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisDGII.DL.Data
{
    public class CarClassData : CRUDModel<CARCLASS>, ICRUDModel<CARCLASS>
    {


        public int CreateIfNotExists(string description)
        {

            var carClass = GetAll().Where(x=>x.CarClassDescription.ToLower() == description.ToLower()).FirstOrDefault();
            if (carClass != null)
            {
                return carClass.CarClassID;
            }
            else
            {
                var newClass = new CARCLASS() { CarClassDescription = description };
                return AddGetObject(newClass).CarClassID;
            }
        }
    }
}
