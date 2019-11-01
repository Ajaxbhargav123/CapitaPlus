using Capitaplus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capitaplus.ViewModel
{
    public class JobSheetForMPLanning
    {
        public IEnumerable<SalesOrder> jobOrders { get; set; }
        public SalesOrder saleOrder { get; set; }
        public BillOfMat bom { get; set; }
        public IEnumerable<BillOfMat> boms { get; set; }
    }
}