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
    
    public partial class SalesOrder
    {
        public int Id { get; set; }
        public string OrderType { get; set; }
        public string PaymentTerm { get; set; }
        public Nullable<int> CreditP { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string CPerson { get; set; }
        public string CNumber { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Type { get; set; }
        public string Capacity { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public Nullable<int> Rate { get; set; }
        public Nullable<int> Stock { get; set; }
        public Nullable<int> SoQty { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<int> GrossAmt { get; set; }
        public Nullable<int> TotalAmt { get; set; }
        public Nullable<int> TotalGrossAmt { get; set; }
        public Nullable<int> Cid { get; set; }
        public string SalesOrderNo { get; set; }
        public Nullable<int> QtyToFreez { get; set; }
        public Nullable<int> QtyTopProduce { get; set; }
        public Nullable<bool> IsCreated { get; set; }
        public string BomNo { get; set; }
        public string JobNo { get; set; }
        public Nullable<bool> IsPlanned { get; set; }
        public Nullable<bool> IsMatIssue { get; set; }
        public Nullable<bool> IsMatRequsite { get; set; }
        public Nullable<int> UpdatedQtyToProduce { get; set; }
    }
}
