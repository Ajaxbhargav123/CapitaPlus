//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Capitaplus.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VendorMaster
    {
        public int S_No { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public string ContactPerson { get; set; }
        public string VendorAddress { get; set; }
        public int SuplierTypeId { get; set; }
        public string SuplierGstNo { get; set; }
        public string ContactNo { get; set; }
    
        public virtual SuplierType SuplierType { get; set; }
    }
}