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
    
    public partial class CARCLASS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CARCLASS()
        {
            this.VEHICULARPARKs = new HashSet<VEHICULARPARK>();
        }
    
        public int CarClassID { get; set; }
        public string CarClassDescription { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VEHICULARPARK> VEHICULARPARKs { get; set; }
    }
}
