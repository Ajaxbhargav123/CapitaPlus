using Capitaplus.Models;
using Capitaplus.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace Capitaplus.Controllers
{
    public class MaterialPlaningController : Controller
    {

        private CapitaplusEntities _capitaContext;
        public string strConnection = ConfigurationManager.ConnectionStrings["FinalDB"].ConnectionString;
        public int Id = 0;

        public MaterialPlaningController()
        {
            _capitaContext = new CapitaplusEntities();
        }
        // GET: MaterialPlaning
        public ActionResult Index()
        {
            return View();
        }

        // GET: BillOfMaterials
        public ActionResult MIS()
        {
            var js = _capitaContext.SalesOrders.Where(c => c.IsCreated == true && c.IsPlanned!=true).ToList();
            var bm = _capitaContext.BillOfMats.ToList();

            if (js.Count == 0)
                return View("NomatPlan");

            var bj = new JobSheetForMPLanning
            {
                boms = bm,
                jobOrders = js
            }; 
            return View(bj);
        }

        //MatPlaning DashBoard
        public ActionResult MatPlaningDash()
        {
            var js = _capitaContext.MatPlannings.Where(c => c.QtyToPurchase>0).ToList(); 
            if (js.Count == 0)
                return View("NomatPlan");

           
            return View(js);
        }

        [HttpPost]
        public void InsertIntoMIS(int wastQty,int Afterwastqty, string salesNo, string MrsNno, string jobno, string bobno, string Code, string ProductlName, string Type, string Capacity, string Color, string Model,   int Qty , int QtyReq, int QtyInStock,  int QtyToProduce)
        {
            try
            {
                int _Id = 0;

                SqlConnection con = new SqlConnection(strConnection); 
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_AddMis", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@jonno", jobno);
                cmd.Parameters.AddWithValue("@bomno", bobno);
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@productName", ProductlName);

                cmd.Parameters.AddWithValue("@Color", Color);
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@Capacity_AMH", Capacity);
                cmd.Parameters.AddWithValue("@Model", Model); 
               
                cmd.Parameters.AddWithValue("@TQty", Qty);
                cmd.Parameters.AddWithValue("@Qtyreq", QtyReq);
                cmd.Parameters.AddWithValue("@qtyinstock",QtyInStock);
                cmd.Parameters.AddWithValue("@qtytopro", QtyToProduce);
                cmd.Parameters.AddWithValue("@waste", wastQty);
                cmd.Parameters.AddWithValue("@qtyAfterWsste", Afterwastqty);
                cmd.Parameters.AddWithValue("@mrsno", MrsNno);
                cmd.Parameters.AddWithValue("@salesno", salesNo); 
  
                _Id = Convert.ToInt32(cmd.ExecuteScalar());


            }
            catch (Exception re)
            {

            }

        }
         
        [HttpPost]
        public void InsertIntoCheckMat(string jobno, string bobno, string Code, string ProductlName, string Type, string Capacity, string Color, string Model, int Qty, string Brand)
        {
            try
            {
                int _Id = 0;

                SqlConnection con = new SqlConnection(strConnection);

                con.Open();
                SqlCommand cmd = new SqlCommand("sp_AddCheckMat", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@jonno", jobno);
                cmd.Parameters.AddWithValue("@bomno", bobno);
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@productName", ProductlName);

                cmd.Parameters.AddWithValue("@Color", Color);
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@Capacity_AMH", Capacity);
                cmd.Parameters.AddWithValue("@Model", Model);

                cmd.Parameters.AddWithValue("@TQty", Qty);
                cmd.Parameters.AddWithValue("@brand", Brand);
                _Id = Convert.ToInt32(cmd.ExecuteScalar());


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
                SqlCommand cmd1 = new SqlCommand("sp_getMrsId", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;

                int Id = Convert.ToInt32(cmd1.ExecuteScalar());
                return Id;
            }
        }

        public int GetStockFromFg(string procode)
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            {
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("sp_getStockFromRawMat", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@procode", procode);
                int Id = Convert.ToInt32(cmd1.ExecuteScalar());
                return Id;
            }
        }
        public void UpdateStatus(string saleNo, string code, string jobno,string bomno)
        {
            // Updating Quantity
            using (SqlConnection con2 = new SqlConnection(strConnection))
            {
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("UpdateStatusInSalesOrderFromMatPlanning", con2);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                cmd2.Parameters.AddWithValue("@sono", saleNo);
                cmd2.Parameters.AddWithValue("@code", code);
                cmd2.Parameters.AddWithValue("@jonno", jobno);
                cmd2.Parameters.AddWithValue("@bom", bomno);
                cmd2.Parameters.AddWithValue("@status", true);

                int _Id = Convert.ToInt32(cmd2.ExecuteScalar());

            }
        }

    }
}