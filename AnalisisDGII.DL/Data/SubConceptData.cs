using AnalisisDGII.DL.Generic;
using AnalisisDGII.EL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisDGII.DL.Data
{
    public class SubConceptData : CRUDModel<SUBCONCEPT>, ICRUDModel<SUBCONCEPT>
    {

        public int CreateIfNotExists(string description)
        {
            description = description.Trim();
            if (description.StartsWith("-"))
            {
                description = description.Remove(0, 1).Trim();
            }
            description = description.Replace("  ", " ");
            var SubConcept = GetAll().Where(x => x.SubConceptDescription.ToLower().Trim() == description.ToLower().Trim()).FirstOrDefault();
            if (SubConcept != null)
            {
                return SubConcept.SubConceptID;
            }
            else
            {
                var newSubConcept = new SUBCONCEPT() { SubConceptDescription = description };
                return AddGetObject(newSubConcept).SubConceptID;
            }
        }
    }
}
