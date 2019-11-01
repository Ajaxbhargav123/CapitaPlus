using Capitaplus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capitaplus.ViewModel
{
    public class CustomerMasterVM
    {
        public IEnumerable<SuplierType> supplierTypes { get; set; }
        public IEnumerable<CustomerType> custTypes { get; set; }
        public CustomerMaster customerMaster { get; set; }
 
    }
}