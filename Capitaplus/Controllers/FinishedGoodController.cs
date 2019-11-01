using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capitaplus.Models;
using Capitaplus.ViewModel;

namespace Capitaplus.Controllers
{
    public class FinishedGoodController : Controller
    {
        private CapitaplusEntities _capitaContext;
        public string strConnection = ConfigurationManager.ConnectionStrings["FinalDB"].ConnectionString;
        public int Id = 0;
        public FinishedGoodController()
        {
            _capitaContext = new CapitaplusEntities();
        }
        // GET: FinishedGood
        public ActionResult Index()
        {
            var custmList = _capitaContext.CustomerMasters.ToList(); 
            var custList = new CustomerListWithFgVM
            {
                customerMasters = custmList 
            };
            return View(custList);
        }

        public ActionResult EditIndex()
        {
            return View();
        }

      

        public ActionResult GetBomDetails(string code)
        {
            var billDetails = _capitaContext.BillOfMats.Where(c => c.MasterProCode == code);

            return Json(new JsonResult { Data = billDetails }, JsonRequestBehavior.AllowGet);
        }

        //Bom ForFG
        public ActionResult UniqueBOM()
        {
            var billDetails = _capitaContext.sp_getBomOfLastGenerated().ToList();

            return Json(new JsonResult { Data = billDetails }, JsonRequestBehavior.AllowGet);
        }
        public void Insert(string Code, string proName, string proshortname,string ismin, string colorshortname, string brand, string brandshortname, string custname,int cid, string Type, string Capacity_AMH, string Color, string Model, int stock, int stockfrezz,int selfstock, string stocktype,string tlfstock ,int max,int min,int gst,int rate,string sac,string uom)
        { 
            try
            {
                int _Id = 0;

                SqlConnection con = new SqlConnection(strConnection);

                con.Open();
                SqlCommand cmd = new SqlCommand("sp_AddFgGoods", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@productName", proName);
                cmd.Parameters.AddWithValue("@Color", Color);
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@Capacity_AMH", Capacity_AMH);
                cmd.Parameters.AddWithValue("@Model", Model);
                cmd.Parameters.AddWithValue("@brand", brand);
                cmd.Parameters.AddWithValue("@customerName", custname.ToString());
                cmd.Parameters.AddWithValue("@cid", cid);
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.Parameters.AddWithValue("@selfstock", selfstock);
                cmd.Parameters.AddWithValue("@stockfrezz", 0);
                cmd.Parameters.AddWithValue("@stockType", stocktype);
                cmd.Parameters.AddWithValue("@trfselg", tlfstock);
                cmd.Parameters.AddWithValue("@rate", rate);
                cmd.Parameters.AddWithValue("@max", max);
                cmd.Parameters.AddWithValue("@min", min);
                cmd.Parameters.AddWithValue("@IsMinMax", ismin);

                cmd.Parameters.AddWithValue("@gst", gst);
                cmd.Parameters.AddWithValue("@shortProCode", proshortname);
                cmd.Parameters.AddWithValue("@shortColorCode", colorshortname);
                cmd.Parameters.AddWithValue("@shortBrandCode", brandshortname);

                cmd.Parameters.AddWithValue("@sac", sac);
                cmd.Parameters.AddWithValue("@uom", uom);
                _Id = Convert.ToInt32(cmd.ExecuteScalar());


            }
            catch (Exception re)
            {

            } 
        }

        public int IsDuplicateData(string proName, string brand, string Type, string Capacity_AMH, string Color, string Model,string stocktype,int cid)
        {
            var getRm = _capitaContext.FinishedGoods.ToList();

            foreach (var item in getRm)
            {
                if (stocktype.Trim() == "Customer")
                {
                    if (item.StockType.Trim() == "Customer" && item.Cid==cid && item.Brand.Trim().ToLower() == brand.Trim().ToLower() && item.CellType.Trim().ToLower() == Type.Trim().ToLower() && item.Capacity.Trim().ToLower() == Capacity_AMH.Trim().ToLower() && item.ProductName.Trim().ToLower() == proName.Trim().ToLower() && item.Color.Trim() == Color.Trim() && item.ModelNo.Trim() == Model.Trim())
                    {
                        return 0;
                    } 
                }
                if (stocktype.Trim() == "Self")
                {
                    if (item.StockType.Trim() == "Self" && item.Brand.Trim().ToLower() == brand.Trim().ToLower() && item.CellType.Trim().ToLower() == Type.Trim().ToLower() && item.Capacity.Trim().ToLower() == Capacity_AMH.Trim().ToLower() && item.ProductName.Trim().ToLower() == proName.Trim().ToLower() && item.Color.Trim() == Color.Trim() && item.ModelNo.Trim() == Model.Trim())
                    {
                        return 0;
                    } 
                } 
                else
                {
                }
            }
            return 1;
        }

        [HttpPost]
        public void InsertIntoStockTable(string salesId, string Wipno, string JobNo, string salesNo, string BomNo, string ProductCode, int location, int mat1, int mat2, int mat3, int mat4, int mat5, int mat6, int mat7, int mat8, int mat9, int mat10, string QCNo, string Qcpass, string rework, string qcRework, string productSerialNo,string custNo)
        { 
                try
                {

                    int _Id = 0;
                    SqlConnection con = new SqlConnection(strConnection);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_AddStockTable", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@wipno", "NA");
                    cmd.Parameters.AddWithValue("@jobno", "NA"); 
                    cmd.Parameters.AddWithValue("@salesId", null);
                cmd.Parameters.AddWithValue("@bomno", BomNo);
                    cmd.Parameters.AddWithValue("@location", location);
                    cmd.Parameters.AddWithValue("@procode", ProductCode);
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
                    cmd.Parameters.AddWithValue("@custNo", custNo);
                    cmd.Parameters.AddWithValue("@qcno", "NA");
                    cmd.Parameters.AddWithValue("@qcpass", "NA");
                    cmd.Parameters.AddWithValue("@rework", "NA");

                    cmd.Parameters.AddWithValue("@qcrework", "NA");
                    cmd.Parameters.AddWithValue("@prodSerialNo", productSerialNo);
                    _Id = Convert.ToInt32(cmd.ExecuteScalar());


                }

                catch (Exception re)
                {

                } 
        }


        public ActionResult FgList()
        {
            var FgList = _capitaContext.FinishedGoods.ToList();
            return View(FgList);
        }

        public ActionResult FGEdit(int id)
        {
            var fgEdit = _capitaContext.FinishedGoods.SingleOrDefault(v => v.Id == id);
            if (fgEdit == null)
                return HttpNotFound(); 
            
            return View("EditIndex", fgEdit);
        }

        public ActionResult Edit(FinishedGood fg)
        {
            if (fg.Id != 0)
            {
                var vendorIbDB = _capitaContext.FinishedGoods.Single(v => v.Id == fg.Id);
                fg.ProductCode = fg.ProductName.Substring(0, 4) + "00" + fg.ShortColorCode.Substring(0, 3) + fg.Capacity;
                vendorIbDB.ProductName = fg.ProductName;
                vendorIbDB.ProductCode = fg.ProductCode;
                vendorIbDB.CellType = fg.CellType;
                vendorIbDB.Capacity = fg.Capacity;
                vendorIbDB.Color = fg.Color;
                vendorIbDB.Brand = fg.Brand;

                vendorIbDB.ShortBrandCode = fg.ShortBrandCode;
                vendorIbDB.ShortColorCode = fg.ShortColorCode;
                vendorIbDB.ShortProductName = fg.ShortProductName;
                vendorIbDB.UOM = fg.UOM;
                vendorIbDB.Stock = fg.Stock;
                vendorIbDB.GST = fg.GST;

                vendorIbDB.Rate = fg.Rate;
                vendorIbDB.MIN = fg.MIN;
                vendorIbDB.Max = fg.Max;
                vendorIbDB.SAC = fg.SAC;

            }
            _capitaContext.SaveChanges();
            return RedirectToAction("Index", "FinishedGood");
        }

        public ActionResult FgProductshortName(string proName)
        {
            var productList = _capitaContext.ProductMasters.Where(x=>x.ProductName==proName).ToList();
            return Json(new JsonResult { Data = productList }, JsonRequestBehavior.AllowGet);
        }

    }
}