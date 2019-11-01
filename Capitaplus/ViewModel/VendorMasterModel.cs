using Capitaplus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capitaplus.ViewModel
{
    public class VendorMasterModel
    {
        public IEnumerable<SuplierType> supplierTypes { get; set; }
        public VendorMaster vendorMaster { get; set; }
    }
}