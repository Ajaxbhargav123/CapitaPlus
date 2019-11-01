using Capitaplus.Models;
 
using System.Collections.Generic;
 

namespace Capitaplus.ViewModel
{
    public class purchaseVm
    {
        public IEnumerable<RoleMaterialCreation> rolematarials { get; set; }
        public RoleMaterialCreation rolematerial { get; set; }
        public VendorMaster vendormasterDetails { get; set; }
    }
}