using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capitaplus.Models;

namespace Capitaplus.ViewModel
{
    public class PoAgainstRoleVm
    {
        public VendorMaster customer { get; set; }
        public IEnumerable<VendorMaster> customers { get; set; }

        public IEnumerable<POType> potypes { get; set; }
        public POType potype { get; set; }
    }
}