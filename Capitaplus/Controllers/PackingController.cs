using Capitaplus.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capitaplus.Controllers
{
    public class PackingController : Controller
    {
        private CapitaplusEntities _capitaContext;
        public string strConnection = ConfigurationManager.ConnectionStrings["FinalDB"].ConnectionString;
        public int Id = 0;

        public PackingController()
        {
            _capitaContext = new CapitaplusEntities();
        }
        // GET: Packing
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetFromStockIfIndYes(string jobno)
        {
            var stocks = _capitaContext.sp_getPackingMaterialIfIndiPacYes(jobno).ToList();
            return Json(new JsonResult { Data = stocks }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetFromStockIfBocPacYes(string jobno)
        {
            var stocks = _capitaContext.sp_getPackingMaterialIfBoxPacYes(jobno).ToList();
            return Json(new JsonResult { Data = stocks }, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult GetQtyOfPacType(string jobno, int PacType)
        //{
        //    var stocks = _capitaContext.sp_GetPacTypeQtyOnPacType(jobno, PacType).ToList();
        //    return Json(new JsonResult
        //    {
        //        Data = stocks
        //    }, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult GetYesIndivisual(string jobno)
        {
            var stocks = _capitaContext.sp_getDataOfPakingType(jobno).ToList();
            return Json(new JsonResult
            {
                Data = stocks
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetYesBox(string jobno)
        {
            var stocks = _capitaContext.sp_getDataOfPakingTypeBox(jobno).ToList();
            return Json(new JsonResult
            {
                Data = stocks
            }, JsonRequestBehavior.AllowGet);
        }


        public void UpdateStocksTableFromPacking(string jobno, string proserialNo, string IndivisualPacking ,string BoxPacking,string boxPacNo)
        {
            using (SqlConnection con2 = new SqlConnection(strConnection))
            { 
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("sp_UpdateStockTablePacking", con2);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                cmd2.Parameters.AddWithValue("@jobno", jobno);
                cmd2.Parameters.AddWithValue("@procodeSerialNo", proserialNo);
                cmd2.Parameters.AddWithValue("@boxPacSerialNo", boxPacNo);
                cmd2.Parameters.AddWithValue("@location", 5);
                cmd2.Parameters.AddWithValue("@indPac", IndivisualPacking);
                cmd2.Parameters.AddWithValue("@boxPac", BoxPacking);

                int _Id = Convert.ToInt32(cmd2.ExecuteScalar());

            }
        }
    }
}