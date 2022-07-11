using AnalisisDGII.DL.Generic;
using AnalisisDGII.EL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisDGII.DL.Data
{
    public class CarOriginData : CRUDModel<CARORIGIN>, ICRUDModel<CARORIGIN>
    {
        public int CreateIfNotExists(string description)
        {
            var carOrigin = GetAll().Where(x => x.CarOriginDescription == description).FirstOrDefault();
            if (carOrigin != null)
            {
                return carOrigin.CarOriginID;
            }
            else
            {
                var newOrigin = new CARORIGIN() { CarOriginDescription = description };
                return AddGetObject(newOrigin).CarOriginID;
            }
        }
    }
}
