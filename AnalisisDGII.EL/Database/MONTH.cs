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
    
    public partial class MONTH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MONTH()
        {
            this.CASHCOLLECTIONs = new HashSet<CASHCOLLECTION>();
            this.VEHICULARPARKs = new HashSet<VEHICULARPARK>();
        }
    
        public int MonthID { get; set; }
        public string MonthDesc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CASHCOLLECTION> CASHCOLLECTIONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VEHICULARPARK> VEHICULARPARKs { get; set; }
    }
}