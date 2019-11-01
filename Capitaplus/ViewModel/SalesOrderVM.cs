using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capitaplus.Models;


namespace Capitaplus.ViewModel
{
    public class SalesOrderVM
    {
        public IEnumerable<FinishedGood> fgGoods { get; set; }
        public FinishedGood fgGood { get; set; }
        public CustomerMaster customers { get; set; }
        public IEnumerable<MasterPackingType> packingType { get; set; }
     }
}