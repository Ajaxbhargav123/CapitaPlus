using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capitaplus.Models;

namespace Capitaplus.ViewModel
{
    public class GgAndRmVm
    {
        public IEnumerable<RoleMaterialCreation> rms { get; set; }
        public RoleMaterialCreation rm { get; set; }
        public FinishedGood fg { get; set; }
        public IEnumerable<FinishedGood> fgs { get; set; }
        public sp_lASTiNSERTEDfG_Result fgby { get; set; }
        public IEnumerable<sp_lASTiNSERTEDfG_Result> fgsby { get; set; }
    }
}