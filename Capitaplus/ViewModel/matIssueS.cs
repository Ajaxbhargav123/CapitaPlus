using Capitaplus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capitaplus.ViewModel
{
    public class matIssueS
    {
        public IEnumerable<sp_geMatIssueSlip_Result> jobOrders { get; set; }
        public sp_geMatIssueSlip_Result saleOrder { get; set; }
        public BillOfMat bom { get; set; }
        public IEnumerable<BillOfMat> boms { get; set; }
        public MaterialRequsitionSlip mrs { get; set; }
        public IEnumerable<MaterialRequsitionSlip> mrss { get; set; }
    }
}