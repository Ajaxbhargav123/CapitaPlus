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
    public class ReworkAreaController : Controller
    {
        private CapitaplusEntities _capitaContext;
        public string strConnection = ConfigurationManager.ConnectionStrings["FinalDB"].ConnectionString;
        public int Id = 0;

        public ReworkAreaController()
        {
            _capitaContext = new CapitaplusEntities();
        }

        // GET: ReworkArea
        public ActionResult Index()
        {
            var qualityCheck = _capitaContext.StockTables.Where(x=>x.QcPass== "Rework" && x.Rework=="NA").ToList();
            if (qualityCheck.Count() == 0)
            {
                return View("NoReworkView");
            }

            var bom= qualityCheck.FirstOrDefault(c => c.BomNo == c.BomNo).BomNo;
            var allDetail = new ReworkAreaMatName
            {
                stockReworks=qualityCheck,
                bom=bom
            };
            return View(allDetail);
        }

        public ActionResult GetMatNameFromBom(string bomNo)
        {
            var getprocode = _capitaContext.sp_getRmCodeFromBom(bomNo).ToList();

            return Json(new JsonResult { Data = getprocode }, JsonRequestBehavior.AllowGet);


        }
        public void UpdateStocksTableRework(string wipno, string proserialNo,string rework)
        {
            using (SqlConnection con2 = new SqlConnection(strConnection))
            { 
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("sp_UpdateStockTableAfterRework", con2);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                cmd2.Parameters.AddWithValue("@wipno", wipno); 
                cmd2.Parameters.AddWithValue("@procodeSerialNo", proserialNo);
                cmd2.Parameters.AddWithValue("@rework", rework);
                
                int _Id = Convert.ToInt32(cmd2.ExecuteScalar());

            }
        }
    }
}