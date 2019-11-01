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
    public class BillOfMaterialsController : Controller
    {
        
        private CapitaplusEntities _capitaContext;
        public string strConnection = ConfigurationManager.ConnectionStrings["FinalDB"].ConnectionString;
        public int Id = 0;
        public BillOfMaterialsController()
        {
            _capitaContext = new CapitaplusEntities();
        }
        // GET: BillOfMaterials
        public ActionResult Index()
        {
            return View();
        } 

        // GET: BillOfMaterials
        public ActionResult BOMIndex()
        {
            var rm = _capitaContext.RoleMaterialCreations.ToList();
            var fg = _capitaContext.FinishedGoods.ToList();

            var fgAndRm = new GgAndRmVm
            {
                rms = rm,
                fgs = fg
            };

            return View(fgAndRm);
        }

        //Get: Bill Of Material BY Fg
        public ActionResult BOMIndexByFg()
        {
            var rm = _capitaContext.RoleMaterialCreations.ToList();
            var fg = _capitaContext.sp_lASTiNSERTEDfG().ToList();

            var fgAndRm = new GgAndRmVm
            {
                rms = rm,
                fgsby = fg
            };

            return View(fgAndRm);
        }

        // GET: BillOfMaterials
        public ActionResult GetFg(string code)
        {
            var FG = _capitaContext.FinishedGoods.Where(x => x.ProductCode == code);

            return Json(new JsonResult { Data = FG }, JsonRequestBehavior.AllowGet);
        }

        // GET: BillOfMaterials
        public ActionResult GetRm(string code)
        {
            var RM = _capitaContext.RoleMaterialCreations.Where(x => x.Code == code);

            return Json(new JsonResult { Data = RM }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
       
       
        public int GetLastId(string code)
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            {
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("sp_getBOMId", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@code", code);

                int Id = Convert.ToInt32(cmd1.ExecuteScalar());
                return Id;
            }
        }

        [HttpPost]
        public void Insert(string Code, string MaterialName, string Type, string Capacity_AMH, string Color, string Model, string MasterCode,int Qty)
        {
            try
            {
                int _Id = 0;
                MasterCode = MasterCode.Trim();
                SqlConnection con = new SqlConnection(strConnection);

                con.Open();
                SqlCommand cmd = new SqlCommand("sp_AddBom", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@MaterialName", MaterialName);
               
                cmd.Parameters.AddWithValue("@Color", Color);
                cmd.Parameters.AddWithValue("@Type", Type);
               
                cmd.Parameters.AddWithValue("@Capacity_AMH", Capacity_AMH);
                cmd.Parameters.AddWithValue("@Model", Model);
                cmd.Parameters.AddWithValue("@Qty", Convert.ToInt32(Qty));
                cmd.Parameters.AddWithValue("@masterCode", MasterCode);


                _Id = Convert.ToInt32(cmd.ExecuteScalar());


            }
            catch (Exception re)
            {
                
            }
             
        }
        // GET: PurchaseOrder  Material Code 
        
    }
}