using Capitaplus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capitaplus.ViewModel
{
    public class RMCreationWithCodeVM
    {
        public string RMCode { get; set; }
        public RoleMaterialCreation rmCreation { get; set; }
        public IEnumerable<StatusYesNo> isYesNos { get; set; }
        public StatusYesNo isYesNo { get; set; }


    }
}