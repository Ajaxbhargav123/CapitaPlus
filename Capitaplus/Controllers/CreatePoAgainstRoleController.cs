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
    public class CreatePoAgainstRoleController : Controller
    {
        public int Id = 0;
        private CapitaplusEntities _capitaContext;
        public string strConnection = ConfigurationManager.ConnectionStrings["FinalDB"].ConnectionString;

        public CreatePoAgainstRoleController()
        {
            _capitaContext = new CapitaplusEntities();
        }

        // GET: CreatePoAgainstRole
        public ActionResult Index()
        {
            var custList = _capitaContext.VendorMasters.ToList();
            var poTypes = _capitaContext.POTypes.ToList();
            var PoAgainst = new PoAgainstRoleVm
            {
                customers = custList,
                potypes = poTypes
            };
            return View(PoAgainst);
        }

        public ActionResult GetUniqueMatPlanning()
        {
            var matPlan = _capitaContext.sp_UniqueMatPlanningForAgainstPO().Where(c => c.RowsNo == 1).ToList();

            return Json(new JsonResult { Data = matPlan }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataMatPlanningByMpn(string mpn)
        {
            var matPlan = _capitaContext.sp_GetCodeByMatPlanningNo(mpn).ToList();

            return Json(new JsonResult { Data = matPlan }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataPoByCode(string code)
        {
            var matPlan = _capitaContext.sp_getPobyCode(code).ToList();

            return Json(new JsonResult { Data = matPlan }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataMatPlanningByCode(string code)
        {
            var matPlan = _capitaContext.getAllTypeQtyFromMatPlanning(code).ToList();

            return Json(new JsonResult { Data = matPlan }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataAgainstReorder()
        {
            var matPlan = _capitaContext.sp_AgaintReorderTypwRM().ToList(); 
            return Json(new JsonResult { Data = matPlan }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataAgainstOther()
        {
            var matPlan = _capitaContext.RoleMaterialCreations.Where(x=>x.UpdatedStock>0).ToList();

            return Json(new JsonResult { Data = matPlan }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void Insert(int ReqQty,int potype,int Quantity, string Code, string MaterialName, string MaterialGroup, string UOM_1, string Type, string Capacity_AMH, string Color, string Model, int? Fridge, string Sac, int Amount, string GrossAmount, string GrossTotal, string NetAmount, int Qty, string VN, int VI, string PurId, int Rate, int GstAmt, int GstTotal)
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
                cmd.Parameters.AddWithValue("@StockQty", Convert.ToInt32(Qty));
                cmd.Parameters.AddWithValue("@Purquantity", Convert.ToInt32(Quantity));
                cmd.Parameters.AddWithValue("@Reqquantity", Convert.ToInt32(ReqQty));
                cmd.Parameters.AddWithValue("@entyDate", Convert.ToDateTime(DateTime.Now.ToShortDateString()));

                cmd.Parameters.AddWithValue("@Amount", Convert.ToInt32(Amount));
                cmd.Parameters.AddWithValue("@GrossAmount", GrossAmount);
                cmd.Parameters.AddWithValue("@GrossTotal", GrossTotal);
                cmd.Parameters.AddWithValue("@NetAmount", NetAmount);

                cmd.Parameters.AddWithValue("@gstAmt", GstAmt);
                cmd.Parameters.AddWithValue("@gstTotal", GstTotal);

                cmd.Parameters.AddWithValue("@vendorN", VN);
                cmd.Parameters.AddWithValue("@vendorId", VI);
                cmd.Parameters.AddWithValue("@rate", Rate);
                cmd.Parameters.AddWithValue("@potype", potype);
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

        public void UpdateStatus(string mrs,string code)
        {
            if (mrs == null)
                return;
            // Updating Quantity
            using (SqlConnection con2 = new SqlConnection(strConnection))
            {
                con2.Open(); 
                SqlCommand cmd2 = new SqlCommand("sp_UpdatePoFlagInMatPlanning", con2);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;  
                cmd2.Parameters.AddWithValue("@mpno", mrs);
                cmd2.Parameters.AddWithValue("@code", code);
                int _Id = Convert.ToInt32(cmd2.ExecuteScalar());

            }
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
    }
}