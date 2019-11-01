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
    public class StockTransferController : Controller
    {
        public int Id = 0;
        private CapitaplusEntities _capitaContext;
        public string strConnection = ConfigurationManager.ConnectionStrings["FinalDB"].ConnectionString;
        // GET: JobCard
        public StockTransferController()
        {
            _capitaContext = new CapitaplusEntities();
        }
        // GET: StockTransfer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetFromStock(string jobno , int location)
        {
            var stocks = _capitaContext.StockTables.Where(x => x.JobNo == jobno && x.Location==location).ToList();
            return Json(new JsonResult { Data = stocks }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFromStockWhenFromTwo(string jobno, int fromlocation)
        {
            var stocks = _capitaContext.StockTables.Where(x => x.JobNo == jobno && x.Location == fromlocation).ToList();
            return Json(new JsonResult { Data = stocks }, JsonRequestBehavior.AllowGet);
        }
       

        public void UpdateStocksTable(string jobno,int fromLoc, int location,string serialcode, string qcremark)
        {
            if (qcremark == "Rework")
            { 
                using (SqlConnection con2 = new SqlConnection(strConnection))
                {
                    SqlTransaction transaction = con2.BeginTransaction();
                    try
                    {
                        con2.Open();
                        SqlCommand cmd2 = new SqlCommand("sp_UpdateStockTable", con2);
                        cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd2.Parameters.AddWithValue("@jobno", jobno);
                        cmd2.Parameters.AddWithValue("@fromloc", fromLoc);
                        cmd2.Parameters.AddWithValue("@location", location);
                        cmd2.Parameters.AddWithValue("@serialno", serialcode);

                        int _Id = Convert.ToInt32(cmd2.ExecuteScalar());
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                    }
                }
            } 
        }

        public void UpdateStocksTableFromTwoTo8(string jobno, int fromLoc, int location, string serialcode, string qcremark)
        {
            if (qcremark == "Scrap")
            {
                using (SqlConnection con2 = new SqlConnection(strConnection))
                {
                    con2.Open();
                    SqlCommand cmd2 = new SqlCommand("sp_UpdateStockTable", con2);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd2.Parameters.AddWithValue("@jobno", jobno);
                    cmd2.Parameters.AddWithValue("@fromloc", fromLoc);
                    cmd2.Parameters.AddWithValue("@location", location);
                    cmd2.Parameters.AddWithValue("@serialno", serialcode);

                    int _Id = Convert.ToInt32(cmd2.ExecuteScalar()); 
                }
            } 
        }

        public void UpdateStocksTableFromTwoTo4(string jobno, int fromLoc, int location, string serialcode, string qcPass)
        {
            if (qcPass == "Ok")
            {
                using (SqlConnection con2 = new SqlConnection(strConnection))
                {
                    con2.Open();
                    SqlCommand cmd2 = new SqlCommand("sp_UpdateStockTable", con2);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd2.Parameters.AddWithValue("@jobno", jobno);
                    cmd2.Parameters.AddWithValue("@fromloc", fromLoc);
                    cmd2.Parameters.AddWithValue("@location", location);
                    cmd2.Parameters.AddWithValue("@serialno", serialcode);

                    int _Id = Convert.ToInt32(cmd2.ExecuteScalar());

                }
            }


        }

        public void UpdateStocksTableFromOneTo2(string jobno, int fromLoc, int location, string serialcode)
        { 
                using (SqlConnection con2 = new SqlConnection(strConnection))
                {
                    con2.Open();
                    SqlCommand cmd2 = new SqlCommand("sp_UpdateStockTable", con2);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd2.Parameters.AddWithValue("@jobno", jobno);
                    cmd2.Parameters.AddWithValue("@fromloc", fromLoc);
                    cmd2.Parameters.AddWithValue("@location", location);
                    cmd2.Parameters.AddWithValue("@serialno", serialcode);

                    int _Id = Convert.ToInt32(cmd2.ExecuteScalar()); 
                } 
        }

        public ActionResult GetMatNameFromBom(string bomNo)
        {
            var getprocode = _capitaContext.sp_getRmCodeFromBom(bomNo).ToList(); 
            return Json(new JsonResult { Data = getprocode }, JsonRequestBehavior.AllowGet); 
        }
    }
}