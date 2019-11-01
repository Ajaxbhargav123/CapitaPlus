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
    public class QualityCheckController : Controller
    {
        private CapitaplusEntities _capitaContext;
        public string strConnection = ConfigurationManager.ConnectionStrings["FinalDB"].ConnectionString;
        public int Id = 0; 
        public QualityCheckController()
        {
            _capitaContext = new CapitaplusEntities();
        }
        // GET: QualityCheck
        public ActionResult Index()
        {
            var allFromStockTable = _capitaContext.sp_UniqueWipFromStocktable().ToList();
            return View(allFromStockTable);
        }
         
        //Rework insert
        [HttpPost]
        public void UpdateIntoQualityCheck(int mat1, int mat2, int mat3, int mat4, int mat5, int mat6, int mat7, int mat8, int mat9, int mat10, string qccheck, string qcNo, string jobno, string wipno, string procodeNo, string bom, string code)
        {
            try
            {
                int _Id = 0;
                SqlConnection con = new SqlConnection(strConnection);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_UpdateStockTableAfterQualitycheck", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@jobno", jobno);
                cmd.Parameters.AddWithValue("@wipno", wipno);
                cmd.Parameters.AddWithValue("@procodeSerialNo", procodeNo);

                cmd.Parameters.AddWithValue("@qCNo", "QCNO" + DateTime.Now.Date.ToString("ddMMyy") + "00000" + qcNo);

                if (qccheck == "Ok")
                {
                    cmd.Parameters.AddWithValue("@qcpass", "Ok");
                }
                if (qccheck == "Rework")
                {
                    cmd.Parameters.AddWithValue("@qcpass", "Rework");
                }
                if (qccheck == "Scrap")
                {
                    cmd.Parameters.AddWithValue("@qcpass", "Scrap");
                }
                cmd.Parameters.AddWithValue("@mat1", mat1);
                cmd.Parameters.AddWithValue("@mat2", mat2);
                cmd.Parameters.AddWithValue("@mat3", mat3);
                cmd.Parameters.AddWithValue("@mat4", mat4);
                cmd.Parameters.AddWithValue("@mat5", mat5);
                cmd.Parameters.AddWithValue("@mat6", mat6);
                cmd.Parameters.AddWithValue("@mat7", mat7);
                cmd.Parameters.AddWithValue("@mat8", mat8);
                cmd.Parameters.AddWithValue("@mat9", mat9);
                cmd.Parameters.AddWithValue("@mat10", mat10); 
                _Id = Convert.ToInt32(cmd.ExecuteScalar());


                //    SqlConnection con1 = new SqlConnection(strConnection);
                //    con1.Open();
                //    SqlCommand cmd1 = new SqlCommand("sp_UpdateQtyFromWipAfterQualitycheck", con);
                //    cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                //    cmd1.Parameters.AddWithValue("@jobno", jobno);
                //    cmd1.Parameters.AddWithValue("@wipno", wipno);
                //    cmd1.Parameters.AddWithValue("@bomno", bom);
                //cmd1.Parameters.AddWithValue("@qty", 0);
                //cmd1.Parameters.AddWithValue("@code", code);
                //  int  _Ids = Convert.ToInt32(cmd1.ExecuteScalar()); 

            }
            catch (Exception re)
            {

            }
        }
          
        public int GetLastMrsId()
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            {
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("sp_getQualityId", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;

                int Id = Convert.ToInt32(cmd1.ExecuteScalar());
                return Id;
            }
        }

        [HttpGet]
        public string GetMrsId()
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            {
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("sp_getQualityId", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;

                int Id = Convert.ToInt32(cmd1.ExecuteScalar());

                string purId = "QCNO11041900000" + Id.ToString();
                return purId;
            }
        }

        public int GetLocation(string jobno,string bomno,string wip)
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            {
                try
                {
                    con1.Open();
                    SqlCommand cmd1 = new SqlCommand("sp_CheckLocationfromStockTable", con1);
                    cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@jobno", jobno);
                    cmd1.Parameters.AddWithValue("@bom", bomno);
                    cmd1.Parameters.AddWithValue("@wip", wip);

                    int location = Convert.ToInt32(cmd1.ExecuteScalar());
                    return location;
                }
                finally
                {
                    con1.Close();
                }
               
            }
        }

        public ActionResult GetMatNameFromBom(string bomNo)
        {
            var getprocode = _capitaContext.sp_getRmCodeFromBom(bomNo).ToList();
 
            return Json(new JsonResult { Data = getprocode }, JsonRequestBehavior.AllowGet);

 
        }

        public ActionResult GetProCode(string jobno, string wip, string bomno)
        {
            var getprocode = _capitaContext.sp_getProcode(jobno, wip, bomno).ToArray();
            var getprocodes = _capitaContext.StockTables.Where(c => c.JobNo == jobno && c.WipNo == wip && c.BomNo == bomno).ToList();

            return Json(new JsonResult { Data = getprocodes }, JsonRequestBehavior.AllowGet);
 
        }
    }
}