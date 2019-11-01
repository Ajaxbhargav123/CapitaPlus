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
    public class MaterialRequsitionSlipController : Controller
    {
        private CapitaplusEntities _capitaContext;
        public string strConnection = ConfigurationManager.ConnectionStrings["FinalDB"].ConnectionString;
        public int Id = 0;

        public MaterialRequsitionSlipController()
        {
            _capitaContext = new CapitaplusEntities();
        }
        // GET: MaterialRequsitionSlip
        public ActionResult Index()
        {
            return View();
        }
        // GET: BillOfMaterials
        public ActionResult MIS()
        {
            var js = _capitaContext.sp_GetDataInMatRequsition().Where(c => c.RowsNo == 1).ToList();
            var bm = _capitaContext.BillOfMats.ToList();

            if (js.Count == 0)
                return View("NoMatRequsitionView");

            var bj = new MIS
            {
                boms = bm,
                salesOrderss = js
            };

            return View(bj);
        }

        [HttpPost]
        public void InsertIntoMIS(int? updateqty, string MrsNno,string saleNo,int actualQty,int wastage,int reqWastQty,int reqQty,int BalQtyReq, string jobno, string bobno, string Code, string ProductlName, string Type, string Capacity, string Color, string Model, int Qty)
        {
            try
            {
                int _Id = 0; 
                SqlConnection con = new SqlConnection(strConnection); 
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_AddMislip", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@sales", saleNo);
                cmd.Parameters.AddWithValue("@jonno", jobno);
                cmd.Parameters.AddWithValue("@bomno", bobno);
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@productName", ProductlName);

                cmd.Parameters.AddWithValue("@Color", Color);
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@Capacity_AMH", Capacity);
                cmd.Parameters.AddWithValue("@Model", Model);

                cmd.Parameters.AddWithValue("@TQty", Qty);
                cmd.Parameters.AddWithValue("@ActualQty", actualQty);
                cmd.Parameters.AddWithValue("@wastage", wastage);
                cmd.Parameters.AddWithValue("@ReqWasteqty", reqWastQty);
                cmd.Parameters.AddWithValue("@ReqQty", reqQty);
                cmd.Parameters.AddWithValue("@BalQtyReq", BalQtyReq);

                cmd.Parameters.AddWithValue("MrsNo", MrsNno); 
                cmd.Parameters.AddWithValue("@dates", DateTime.Now);
                _Id = Convert.ToInt32(cmd.ExecuteScalar());

               
              
            }
            catch (Exception re)
            {

            }

        }

        public void Update(string jobno,string code,int qty)
        {
            using (SqlConnection con2 = new SqlConnection(strConnection))
            {
                
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("UpdateQtyInJobSheet", con2);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                cmd2.Parameters.AddWithValue("@jonno", jobno.Trim());
                cmd2.Parameters.AddWithValue("@code", code.Trim());
                cmd2.Parameters.AddWithValue("@RemQty", qty);

               int _Id = Convert.ToInt32(cmd2.ExecuteScalar());

            }
        }

        public void UpdateQtyInMAtPlanning(string code, string jobno, string mat,int mrswastqty,int mrsreqwastqty,int mrsreqqty,int mrsbalqtyreq)
        {
            try
            {
                using (SqlConnection con2 = new SqlConnection(strConnection))
                {
                    con2.Open();
                    SqlCommand cmd2 = new SqlCommand("sp_updateBalQty", con2);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd2.Parameters.AddWithValue("@jobsno", jobno.Trim());
                    cmd2.Parameters.AddWithValue("@matname", mat.Trim());
                    cmd2.Parameters.AddWithValue("@code", code.Trim());
                    
                    cmd2.Parameters.AddWithValue("@mrswastqty", mrswastqty);
                    cmd2.Parameters.AddWithValue("@mrsreqwastqty", mrsreqwastqty);
                    cmd2.Parameters.AddWithValue("@mrsreqqty", mrsreqqty);
                    cmd2.Parameters.AddWithValue("@mrsbalqtyreq", mrsbalqtyreq);


                    int _Id = Convert.ToInt32(cmd2.ExecuteScalar());

                }
            }
            catch (Exception e)
            {

            }

        }

        public int GetLastMrsId()
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            {
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("sp_getMrslipId", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;

                int Id = Convert.ToInt32(cmd1.ExecuteScalar());
                return Id;
            }
        }

        public ActionResult GetDataFromMatRequsition(string job)
        {
            var so = _capitaContext.sp_IsdataAddedInMatReq(job);

            return Json(new JsonResult { Data = so }, JsonRequestBehavior.AllowGet);
        }

      //  Get Data Waste Fro Mat[Planning
        public ActionResult GetDataFromMatPlanning(string job)
        {
            var so = _capitaContext.sp_getWasteFromMatPlanningInRequsition(job); 
            return Json(new JsonResult { Data = so }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public string GetMrsId()
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            {
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("sp_getMrslipId", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;

                int Id = Convert.ToInt32(cmd1.ExecuteScalar());

                string purId = "MRS000" + Id.ToString();
                return purId;
            }
        }

        
    }
}