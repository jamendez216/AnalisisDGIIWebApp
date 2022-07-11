using AnalisisDGII.DL.Generic;
using AnalisisDGII.EL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisDGII.DL.Data
{
    public class RecaudacionEfectivaData : CRUDModel<CASHCOLLECTION>, ICRUDModel<CASHCOLLECTION>
    {
        private DGIIEntities dataContext = new DGIIEntities();

        public void ClearTable()
        {
            dataContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [CASHCOLLECTION]");
        }
    }
}
