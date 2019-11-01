using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capitaplus.Models;
namespace Capitaplus.ViewModel
{
    public class JobSheetVm
    {
        public IEnumerable<SalesOrder> salesOrders { get; set; }
        public SalesOrder saleOrder { get; set; }
        public BillOfMat bom { get; set; }
        public IEnumerable<BillOfMat> boms { get; set; }
    }
}