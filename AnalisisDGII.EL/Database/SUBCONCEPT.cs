//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnalisisDGII.EL.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class SUBCONCEPT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUBCONCEPT()
        {
            this.CASHCOLLECTIONs = new HashSet<CASHCOLLECTION>();
        }
    
        public int SubConceptID { get; set; }
        public string SubConceptDescription { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CASHCOLLECTION> CASHCOLLECTIONs { get; set; }
    }
}
