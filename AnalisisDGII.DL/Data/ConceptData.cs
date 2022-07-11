using AnalisisDGII.DL.Generic;
using AnalisisDGII.EL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisDGII.DL.Data
{
    public class ConceptData : CRUDModel<CONCEPT>, ICRUDModel<CONCEPT>
    {

        public int CreateIfNotExists(string description)
        {
            description = description.Trim();
            if (description.StartsWith("-"))
            {
                description = description.Remove(0, 1);
            }
            description = description.Replace("  ", " ");
            var Concept = GetAll().Where(x => x.ConceptDescription.ToLower().Contains(description.ToLower())).FirstOrDefault();
            if (Concept != null)
            {
                return Concept.ConceptID;
            }
            else
            {
                var newConcept = new CONCEPT() { ConceptDescription = description };
                var addedConcept = AddGetObject(newConcept);
                return addedConcept.ConceptID;
            }

        }
    }
}
