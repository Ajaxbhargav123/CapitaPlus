using Capitaplus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capitaplus.ViewModel
{
    public class ReworkAreaMatName
    {
        public IEnumerable<StockTable> stockReworks { get; set; }
        public StockTable stockRework { get; set; }

        public string bom { get; set; }
    }
}