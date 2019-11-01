using Capitaplus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capitaplus.ViewModel
{
    public class CustomerListWithFgVM
    {
        public IEnumerable<CustomerMaster> customerMasters { get; set; }
        public CustomerMaster customerMaster { get; set; }
        public FinishedGood fg { get; set; }
        public sp_UniqueBOM_Result bom { get; set; }
        public IEnumerable<sp_UniqueBOM_Result> boms { get; set; }

    }
}