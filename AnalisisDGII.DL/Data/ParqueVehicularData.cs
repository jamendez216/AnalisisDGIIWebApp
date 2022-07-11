using AnalisisDGII.DL.Generic;
using AnalisisDGII.EL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisDGII.Data.DL
{
    public class ParqueVehicularData : CRUDModel<VEHICULARPARK>, ICRUDModel<VEHICULARPARK>
    {
        private DGIIEntities dataContext = new DGIIEntities();
        public void ClearTable()
        {
            dataContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [VEHICULARPARK]");
        }

    }

}
