using Capitaplus.Models;
using Capitaplus.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace Capitaplus.Controllers
{
    public class GoodReciptController : Controller
    {
        private CapitaplusEntities _capitaContext;
        public string strConnection = ConfigurationManager.ConnectionStrings["FinalDB"].ConnectionString;
        public int Id = 0;
        public GoodReciptController()
        {
            _capitaContext = new CapitaplusEntities();
        }
        [HttpPost]
        public ActionResult GetDistrict(string stateId)
        {
           
            List<SelectListItem> districtNames = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(stateId))
                
            {

                List<PurchaseOrderSummary> districts = _capitaContext.PurchaseOrderSummaries.Where(x => x.PurchaseId == stateId && x.Qty > 0).ToList();
                districts.ForEach(x =>
                {
                    districtNames.Add(new SelectListItem { Text = x.Code, Value = x.Id.ToString() });
                });
            }
            return Json(districtNames, JsonRequestBehavior.AllowGet);
        }
        
    // GET: GoodRecipt
    public ActionResult Index()
        { 
            return View(); 
        }

        public int GetLastGrnId()
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            {
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("sp_getGRNIdByVendorId", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;

                int Id = Convert.ToInt32(cmd1.ExecuteScalar());
                return Id;
            }
        }

        [HttpGet]
        public string GetGrnId(int VI)
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            {
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("sp_getGRNIdByVendorId", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;

                int Id = Convert.ToInt32(cmd1.ExecuteScalar()); 
                string purId = "0000" + Id.ToString();
                return purId;
            }
        }

        //Check For Duplicate
        public int IsDuplicateData(string gateNo)
        {
            var getRm = _capitaContext.Grns.ToList();

            foreach (var item in getRm)
            {
                if (item.EntryGateNo == gateNo)
                {
                    return 0;
                }
            }
            return 1;
        }

        // Create GRN
        public ActionResult redirectToGrn(int id)
        {  
            var grnCreation = _capitaContext.PurchaseOrderSummaries.Where(x => x.VendorId == id).Where(x => x.Qty > 0).ToList(); 
            var vendorUser = _capitaContext.VendorMasters.SingleOrDefault(v => v.S_No == id);
            var vendorUsers = _capitaContext.PurchaseOrderSummaries.Distinct().FirstOrDefault(v => v.VendorId == id);

            if (vendorUser == null)
                return HttpNotFound();
            List<SelectListItem> stateNames = new List<SelectListItem>();
           
            List<string> states = _capitaContext.sp_UniquePurId(id).ToList();
            
            purchaseOrderVM stuModel = new purchaseOrderVM();
            
                states.ForEach(x =>
                {
                    stateNames.Add(new SelectListItem { Text = x, Value = x.ToString() });
                });
           
            stuModel.StateNames = stateNames;

            var vendorVM = new purchaseOrderVM
            {
                vendormasterDetails = vendorUser,
                order = grnCreation,
                Purorder = vendorUsers,
                 StateNames=stateNames
            };
            return View("Index", vendorVM);
        }

        public void UpdateStockInRawMat(string code, int qty)
        {
            using (SqlConnection con2 = new SqlConnection(strConnection))
            { 
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("sp_UpdateStockInRawMat", con2);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
 
                cmd2.Parameters.AddWithValue("@code", code.Trim());
                cmd2.Parameters.AddWithValue("@updatedQty", qty);

                int _Id = Convert.ToInt32(cmd2.ExecuteScalar());

            }
        }

        [HttpPost] 
        public void save(string entrydate,string recieveDate,string gateNo, string Code, string MaterialName, string UOM_1, string Type, string Capacity_AMH, string Color, string Model, int Amount, int Recive, int Qty, string VN, int VI,string purId,string putIdToUpdate)
        {
            try
            { 
                int _Id = 0;
                using (SqlConnection con = new SqlConnection(strConnection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_AddGrnOrder", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@Code", Code);
                    cmd.Parameters.AddWithValue("@MaterialName", MaterialName);
            
                    cmd.Parameters.AddWithValue("@UOM1", UOM_1);
                    cmd.Parameters.AddWithValue("@Color", Color);
                    cmd.Parameters.AddWithValue("@Type", Type);
                  
                    cmd.Parameters.AddWithValue("@Capacity_AMH", Capacity_AMH);
                    cmd.Parameters.AddWithValue("@Model", Model);
                    cmd.Parameters.AddWithValue("@Qty", Convert.ToInt32(Qty));
                    cmd.Parameters.AddWithValue("@recive", Convert.ToInt32(Recive));
                    cmd.Parameters.AddWithValue("@Amount", Convert.ToInt32(Amount));

                    cmd.Parameters.AddWithValue("@vendorN", VN);
                    cmd.Parameters.AddWithValue("@vendorId", VI);

                    cmd.Parameters.AddWithValue("@entryDate",Convert.ToDateTime(entrydate));
                    cmd.Parameters.AddWithValue("@recieveDate", recieveDate);
                    cmd.Parameters.AddWithValue("@gateno", gateNo);


                    cmd.Parameters.AddWithValue("@PurchaseId","0000"+ purId);
                    cmd.Parameters.AddWithValue("@grnId", putIdToUpdate);

                    _Id = Convert.ToInt32(cmd.ExecuteScalar()); 
                }

                // Updating Quantity
                using (SqlConnection con2 = new SqlConnection(strConnection))
                {
                    int RemainingQty = Qty - Recive;
                    con2.Open();
                    SqlCommand cmd2 = new SqlCommand("UpdateQtyInPo", con2);
                    cmd2.CommandType = CommandType.StoredProcedure;

                    cmd2.Parameters.AddWithValue("@vendorId", VI);
                    cmd2.Parameters.AddWithValue("@Code", Code);
                    cmd2.Parameters.AddWithValue("@RemQty", RemainingQty);
                    cmd2.Parameters.AddWithValue("@purId",  putIdToUpdate);

                    _Id = Convert.ToInt32(cmd2.ExecuteScalar());

                }
            }
            catch (Exception er)
            {
              
            }
        }
    }
}