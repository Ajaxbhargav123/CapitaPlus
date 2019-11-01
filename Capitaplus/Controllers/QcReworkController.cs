using Capitaplus.Models;
using Capitaplus.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capitaplus.Controllers
{
    public class QcReworkController : Controller
    {
        private CapitaplusEntities _capitaContext;
        public string strConnection = ConfigurationManager.ConnectionStrings["FinalDB"].ConnectionString;
        public int Id = 0;

        public QcReworkController()
        {
            _capitaContext = new CapitaplusEntities();
        }

        // GET: QcRework
        public ActionResult Index()
        {
            var RequalityCheck = _capitaContext.StockTables.Where(x => x.Rework.ToUpper() == "No" && x.QcRework=="NA").ToList();
            if (RequalityCheck.Count() == 0)
            {
                return View("NoQcReworkView");
            }
           
            var bom = RequalityCheck.FirstOrDefault(c => c.BomNo == c.BomNo).BomNo;
            var allDetail = new ReworkAreaMatName
            {
                stockReworks = RequalityCheck,
                bom = bom
            };
            return View(allDetail); 
        }

        public ActionResult GetMatNameFromBom(string bomNo)
        {
            var getprocode = _capitaContext.sp_getRmCodeFromBom(bomNo).ToList(); 
            return Json(new JsonResult { Data = getprocode }, JsonRequestBehavior.AllowGet); 
        }

        public void UpdateStocksTableQcRework(string wipno, string proserialNo, string qcrework)
        {
            using (SqlConnection con2 = new SqlConnection(strConnection))
            {

                con2.Open();
                SqlCommand cmd2 = new SqlCommand("sp_UpdateStockTableAfterQCRework", con2);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                cmd2.Parameters.AddWithValue("@wipno", wipno); 
                cmd2.Parameters.AddWithValue("@procodeSerialNo", proserialNo);
                cmd2.Parameters.AddWithValue("@qcrework", qcrework);

                int _Id = Convert.ToInt32(cmd2.ExecuteScalar());

            }
        }
    }
}