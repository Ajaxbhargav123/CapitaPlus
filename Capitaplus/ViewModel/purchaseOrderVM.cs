using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capitaplus.Models;


namespace Capitaplus.ViewModel
{
    public class purchaseOrderVM
    {
        public IEnumerable<PurchaseOrderSummary> order { get; set; }
        public PurchaseOrderSummary Purorder { get; set; }
        public VendorMaster vendormasterDetails { get; set; }

        public IList<SelectListItem> StateNames { get; set; }
        public IList<SelectListItem> DistrictNames { get; set; }
    }
}