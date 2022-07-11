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
    
    public partial class VEHICULARPARK
    {
        public int VehicularParkID { get; set; }
        public int InscriptionYear { get; set; }
        public int MonthID { get; set; }
        public int EntranceYear { get; set; }
        public int CarClassID { get; set; }
        public int CarTypeID { get; set; }
        public int FabricationYear { get; set; }
        public int CarOriginID { get; set; }
        public int CarCompanyID { get; set; }
        public decimal Quantity { get; set; }
    
        public virtual CARCLASS CARCLASS { get; set; }
        public virtual CARCOMPANY CARCOMPANY { get; set; }
        public virtual CARORIGIN CARORIGIN { get; set; }
        public virtual CARTYPE CARTYPE { get; set; }
        public virtual MONTH MONTH { get; set; }
    }
}