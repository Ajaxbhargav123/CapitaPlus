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
    
    public partial class Grn
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string MaterialName { get; set; }
        public string Type { get; set; }
        public string Capacity { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public Nullable<int> Qty { get; set; }
        public string Uom { get; set; }
        public Nullable<int> Receive { get; set; }
        public Nullable<int> Amount { get; set; }
        public string VendorName { get; set; }
        public Nullable<int> VendorId { get; set; }
        public string GrnId { get; set; }
        public string PurId { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<System.DateTime> RecieveDate { get; set; }
        public string EntryGateNo { get; set; }
    }
}
