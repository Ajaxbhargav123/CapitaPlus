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
    public class JobCardController : Controller
    {
        public int Id = 0;
        private CapitaplusEntities _capitaContext;
        public string strConnection = ConfigurationManager.ConnectionStrings["FinalDB"].ConnectionString;
        // GET: JobCard
        public JobCardController()
        {
            _capitaContext = new CapitaplusEntities();
        }
        
        public ActionResult JobSheet()
        {
            var salesOrder = _capitaContext.SalesOrders.Where(x => x.QtyTopProduce > 0 && x.IsCreated!=true).ToList();
            var billOfMat = _capitaContext.BillOfMats.ToList();

            if (salesOrder.Count == 0) 
                return View("jobsheetEmpty"); 

            var jobsheet = new JobSheetVm
            {
                salesOrders = salesOrder,
                boms = billOfMat
            };

            return View(jobsheet);
        }
        public int GetLastMrsId()
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            {
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("sp_getjobId", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;

                int Id = Convert.ToInt32(cmd1.ExecuteScalar());
                return Id;
            }
        }
        public ActionResult GetBom()
        {
            var salesOrder = _capitaContext.BillOfMats.ToList();

            return Json(new JsonResult { Data = salesOrder },JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetBomDetails(string code)
        {
            var billDetails = _capitaContext.BillOfMats.Where(c => c.MasterProCode == code);

            return Json(new JsonResult { Data = billDetails }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDSBySalesOrder(string id,string salesno)
        {
            var so = _capitaContext.DeliverySchedules.Where(c => c.Code == id && c.SalesOrderNo==salesno).ToList();

            return Json(new JsonResult { Data = so }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPIBySalesOrder(string id, string salesNo)
        {
            var so = _capitaContext.SalesOrdersPackings.Where(c => c.Code == id && c.SalesOrderNo==salesNo);

            return Json(new JsonResult { Data = so }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetProductByMasterCode(string code)
        {
            var allProduct = _capitaContext.sp_getAllBomOnMasterProCodeNoId(code);
            return Json(new JsonResult { Data = allProduct }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void Insert(int totalQty, string updateqty, string JObNo,string SalesNo,string Code, string MaterialName,  string Brand, string Type, string Capacity_AMH, string Color, string Model, int? QtyToPro,int QtyInPiece, string BomNo)
        {
            try
            {
                int _Id = 0;
                JObNo = JObNo.Trim();
                SqlConnection con = new SqlConnection(strConnection);

                con.Open();
                SqlCommand cmd = new SqlCommand("sp_AddJobSheet", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@MaterialName", MaterialName);
                cmd.Parameters.AddWithValue("@jobno", JObNo);
                cmd.Parameters.AddWithValue("@salesNo", SalesNo);
                cmd.Parameters.AddWithValue("@Color", Color);
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@bomno", BomNo);
                cmd.Parameters.AddWithValue("@brand", Brand);
                cmd.Parameters.AddWithValue("@Capacity_AMH", Capacity_AMH);
                cmd.Parameters.AddWithValue("@Model", Model);
                cmd.Parameters.AddWithValue("@Qtytopro", Convert.ToInt32(QtyToPro));

                cmd.Parameters.AddWithValue("@qtyinpic", Convert.ToInt32(QtyInPiece));
                cmd.Parameters.AddWithValue("@totalQty", Convert.ToInt32(totalQty));

                _Id = Convert.ToInt32(cmd.ExecuteScalar());


                // Updating Quantity
                using (SqlConnection con2 = new SqlConnection(strConnection))
                {
                    int RemainingQty = 0;
                    con2.Open();
                    SqlCommand cmd2 = new SqlCommand("UpdateQtyInSOPacking", con2);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure; 
                  
                    cmd2.Parameters.AddWithValue("@Code", updateqty);
                    cmd2.Parameters.AddWithValue("@RemQty", RemainingQty);
                    
                    _Id = Convert.ToInt32(cmd2.ExecuteScalar());

                }

                // Updating Quantity
                using (SqlConnection con3 = new SqlConnection(strConnection))
                {
                    
                    con3.Open();
                    SqlCommand cmd3 = new SqlCommand("UpdateBomJobInSO", con3);
                    cmd3.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd3.Parameters.AddWithValue("@jobno", JObNo);
                    cmd3.Parameters.AddWithValue("@bomno", BomNo);
                    cmd3.Parameters.AddWithValue("@code", Code);
                    cmd3.Parameters.AddWithValue("salesno", SalesNo);

                  int  _Ids = Convert.ToInt32(cmd3.ExecuteScalar());

                }
            }
            catch (Exception re)
            { 
            }
            // return IsSuccess;
        }
        
        public void UpdateStatus(string saleNo,string code,int Cid)
        { 
            // Updating Quantity
            using (SqlConnection con2 = new SqlConnection(strConnection))
            { 
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("UpdateStatusInSalesOrder", con2);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                cmd2.Parameters.AddWithValue("@sono", saleNo);
                cmd2.Parameters.AddWithValue("@code", code);
                cmd2.Parameters.AddWithValue("@cid", Cid);
                cmd2.Parameters.AddWithValue("@status", true); 
               int _Id = Convert.ToInt32(cmd2.ExecuteScalar());

            }
        }

        public void UpdateStockTable(string saleNo, string code, string jobno)
        {
            // Updating Quantity
            using (SqlConnection con2 = new SqlConnection(strConnection))
            {
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("sp_UpdateStockTableFromJobSheet", con2);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                cmd2.Parameters.AddWithValue("@productcode", code);
                cmd2.Parameters.AddWithValue("@salesNo", saleNo);
                cmd2.Parameters.AddWithValue("@jobno", jobno);
                
                int _Id = Convert.ToInt32(cmd2.ExecuteScalar()); 
            }
        }

        public void UpdateDSJonNo(string saleNo, string code, string jobno)
        {
            // Updating Quantity
            using (SqlConnection con2 = new SqlConnection(strConnection))
            {
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("sp_UpdateDSJobNoFromJobSheet", con2);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                cmd2.Parameters.AddWithValue("@productcode", code);
                cmd2.Parameters.AddWithValue("@salesNo", saleNo);
                cmd2.Parameters.AddWithValue("@jobno", jobno);

                int _Id = Convert.ToInt32(cmd2.ExecuteScalar());

            }
        }

        public void UpdatePackingJonNo(string saleNo, string code, string jobno)
        {
            // Updating Quantity
            using (SqlConnection con2 = new SqlConnection(strConnection))
            {
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("sp_UpdatePackingJobNoFromJobSheet", con2);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                cmd2.Parameters.AddWithValue("@productcode", code);
                cmd2.Parameters.AddWithValue("@salesNo", saleNo);
                cmd2.Parameters.AddWithValue("@jobno", jobno);

                int _Id = Convert.ToInt32(cmd2.ExecuteScalar());

            }
        }


    }
}