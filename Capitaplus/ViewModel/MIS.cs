using Capitaplus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capitaplus.ViewModel
{
    public class MIS
    {
        public IEnumerable<SalesOrder> salesOrders { get; set; }
        public SalesOrder salOrder { get; set; }
        public IEnumerable<sp_GetDataInMatRequsition_Result> salesOrderss { get; set; }
        public sp_GetDataInMatRequsition_Result salOrders { get; set; }


        public IEnumerable<JobSheet> jobOrders { get; set; }
        public JobSheet saleOrder { get; set; }
        public BillOfMat bom { get; set; }
        public IEnumerable<BillOfMat> boms { get; set; }
    }
}