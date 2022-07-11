using AnalisisDGII.DL.Generic;
using AnalisisDGII.EL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisDGII.DL.Data
{
    public class ISRData : CRUDModel<ISR>, ICRUDModel<ISR>
    {
        private DGIIEntities dataContext = new DGIIEntities();

        public void ClearTable()
        {
            dataContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [ISR]");
        }
    }
}
