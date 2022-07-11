using AnalisisDGII.DL.Generic;
using AnalisisDGII.EL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisDGII.DL.Data
{
    public class CarTypeData : CRUDModel<CARTYPE>, ICRUDModel<CARTYPE>
    {
        public int CreateIfNotExists(CARTYPE model)
        {
            var carType = Get(model.CarTypeID);
            if (carType != null)
            {
                return carType.CarTypeID;
            }
            else
            {
                var createdObject = AddGetObject(model);
                return createdObject.CarTypeID;
            }
        }
    }
}
