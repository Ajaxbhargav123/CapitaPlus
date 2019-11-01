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
    
    public partial class SalesOrdersPacking
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Code { get; set; }
        public string ProductName { get; set; }
        public string CellType { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Capacity { get; set; }
        public string IndivisualPacking { get; set; }
        public Nullable<int> QtyIndivisual { get; set; }
        public string BoxPacking { get; set; }
        public Nullable<int> QtyBox { get; set; }
        public Nullable<int> ReqBox { get; set; }
        public Nullable<int> QtyToProduce { get; set; }
        public string Remark { get; set; }
        public string SalesOrderNo { get; set; }
        public string JobNo { get; set; }
        public Nullable<int> PackingTypeId { get; set; }
        public Nullable<int> PackingTypeQty { get; set; }
    }
}