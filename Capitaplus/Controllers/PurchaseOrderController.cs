using Capitaplus.Models;
using Capitaplus.ViewModel;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace Capitaplus.Controllers
{
    public class PurchaseOrderController : Controller
    {
        public int Id = 0;

        private CapitaplusEntities _capitaContext;
        public string strConnection = ConfigurationManager.ConnectionStrings["FinalDB"].ConnectionString;

        public PurchaseOrderController()
        {
            _capitaContext = new CapitaplusEntities();
        }

        public int GetLastPurId()
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            {
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("sp_getPOIdByVendorId", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;

                int Id = Convert.ToInt32(cmd1.ExecuteScalar());
                return Id;
            }
        }

        [HttpPost]
        public void Insert(int Quantity, string Code, string MaterialName, string MaterialGroup, string UOM_1, string Type, string Capacity_AMH, string Color, string Model, int? Fridge, string Sac, int Amount, string GrossAmount, string GrossTotal, string NetAmount, int Qty, string VN, int VI, string PurId, int Rate, int GstAmt, int GstTotal)
        {
            try
            {
                int _Id = 0;

                SqlConnection con = new SqlConnection(strConnection);

                con.Open();
                SqlCommand cmd = new SqlCommand("sp_AddPurchaseOrder", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@MaterialName", MaterialName);
                cmd.Parameters.AddWithValue("@MaterialGroup", MaterialGroup);
                cmd.Parameters.AddWithValue("@UOM1", UOM_1);
                cmd.Parameters.AddWithValue("@Color", Color);
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@sac", Sac);
                cmd.Parameters.AddWithValue("@fridge", Fridge);
                cmd.Parameters.AddWithValue("@Capacity_AMH", Capacity_AMH);
                cmd.Parameters.AddWithValue("@Model", Model);
                cmd.Parameters.AddWithValue("@Qty", Convert.ToInt32(Qty));
                cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(Quantity));
                cmd.Parameters.AddWithValue("@entyDate", Convert.ToDateTime(DateTime.Now.ToShortDateString()));

                cmd.Parameters.AddWithValue("@Amount", Convert.ToInt32(Amount));
                cmd.Parameters.AddWithValue("@GrossAmount", GrossAmount);
                cmd.Parameters.AddWithValue("@GrossTotal", GrossTotal);
                cmd.Parameters.AddWithValue("@NetAmount", NetAmount);

                cmd.Parameters.AddWithValue("@gstAmt", GstAmt);
                cmd.Parameters.AddWithValue("@gstTotal", GstTotal);
                cmd.Parameters.AddWithValue("@potype", 55);
                cmd.Parameters.AddWithValue("@vendorN", VN);
                cmd.Parameters.AddWithValue("@vendorId", VI);
                cmd.Parameters.AddWithValue("@rate", Rate);
                cmd.Parameters.AddWithValue("@PurchaseId", "0000" + PurId);

                _Id = Convert.ToInt32(cmd.ExecuteScalar());


            }
            catch (Exception re)
            {
                //IsSuccess = false;
                //return IsSuccess;
            }
            // return IsSuccess;
        }
        // GET: PurchaseOrder  Material Code

        [HttpGet]
        public string GetPurId(int VI)
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            {
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("sp_getPOIdByVendorId", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;

                int Id = Convert.ToInt32(cmd1.ExecuteScalar());

                string purId = "0000" + Id.ToString();
                return purId;
            }
        }

        public ActionResult Index()
        {
            var roCreation = _capitaContext.RoleMaterialCreations.ToList();
            var vmPurchaseOrder = new purchaseVm
            {
                rolematarials = roCreation,
            };
            return View(vmPurchaseOrder);
        }
        //Create Po
        public ActionResult redirectToPo(int id)
        {
            var roCreation = _capitaContext.RoleMaterialCreations.ToList();
            var vendorUser = _capitaContext.VendorMasters.SingleOrDefault(v => v.S_No == id);
            if (vendorUser == null)
                return HttpNotFound();

            var vendorVM = new purchaseVm
            {
                vendormasterDetails = vendorUser,
                rolematarials = roCreation
            };
            return View("Index", vendorVM);
        }


    }
}