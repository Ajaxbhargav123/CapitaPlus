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
    public class WIPStockGerController : Controller
    {
        private CapitaplusEntities _capitaContext;
        public string strConnection = ConfigurationManager.ConnectionStrings["FinalDB"].ConnectionString;
        public int Id = 0;

        public WIPStockGerController()
        {
            _capitaContext = new CapitaplusEntities();
        }
        // GET: BillOfMaterials
        public ActionResult MIS()
        { 
            var js = _capitaContext.SalesOrders.Where(c => c.IsCreated == true && c.IsPlanned == true && c.UpdatedQtyToProduce>0).ToList();
            var bm = _capitaContext.BillOfMats.ToList();
            if (js.Count == 0)
                return View("NoWipMatView");
            var bj = new MIS
            {
                boms = bm,
               salesOrders = js
            };
            return View(bj);
        }

        public int GetLastMrsId()
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            {
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("sp_getWipId", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;

                int Id = Convert.ToInt32(cmd1.ExecuteScalar());
                return Id;
            }
        }

        public int GetLastProductCodeId()
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            {
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("sp_getStockMasterProcodeId", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;

                int Id = Convert.ToInt32(cmd1.ExecuteScalar());
                return Id;
            }
        } 
       
        [HttpPost]
        public void InsertIntoMIS(string Wipno, string Code, string ProductlName, string Type, string Capacity, string Color, string Model, int Qty, int sc, int ac, int WastQty,string bom,string jobno,int AvalableQty)
        {
            try
            {
                int _Id = 0;

                SqlConnection con = new SqlConnection(strConnection);

                con.Open();
                SqlCommand cmd = new SqlCommand("sp_AddWIP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id); 
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@productName", ProductlName);

                cmd.Parameters.AddWithValue("@Color", Color);
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@Capacity_AMH", Capacity);
                cmd.Parameters.AddWithValue("@Model", Model);

                cmd.Parameters.AddWithValue("@TQty", Qty);
                cmd.Parameters.AddWithValue("@sc", sc);
                cmd.Parameters.AddWithValue("@ac", ac);
                cmd.Parameters.AddWithValue("@wastQty", WastQty);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@bom", bom);
                cmd.Parameters.AddWithValue("@jobno",jobno);
                cmd.Parameters.AddWithValue("@QtyAtLocation", AvalableQty);
                cmd.Parameters.AddWithValue("@wipno", "WIP000" + Wipno);
                _Id = Convert.ToInt32(cmd.ExecuteScalar());


            }
            catch (Exception re)
            {

            }

        }
         
        [HttpPost]
        public void InsertIntoStockTable(int custno,string Wipno, string JobNo, string salesNo, string BomNo, string ProductCode, int location, int mat1, int mat2, int mat3, int mat4, int mat5, int mat6, int mat7, int mat8, int mat9, int mat10, string QCNo, string Qcpass, string rework, string qcRework, string productSerialNo, int Recive, int Qty)
        { 
            try
            {
                int _Id = 0; 
                SqlConnection con = new SqlConnection(strConnection); 
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_AddStockTable", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@wipno", "WIP000" + Wipno);
                cmd.Parameters.AddWithValue("@jobno", JobNo);
                cmd.Parameters.AddWithValue("@salesId", salesNo);
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
                cmd.Parameters.AddWithValue("@custNo", custno);
                cmd.Parameters.AddWithValue("@qcno", QCNo);
                cmd.Parameters.AddWithValue("@qcpass", Qcpass);
                cmd.Parameters.AddWithValue("@rework", rework);

                cmd.Parameters.AddWithValue("@qcrework", qcRework);
                cmd.Parameters.AddWithValue("@prodSerialNo", productSerialNo);
                _Id = Convert.ToInt32(cmd.ExecuteScalar());

                // Updating Quantity
                using (SqlConnection con2 = new SqlConnection(strConnection))
                {
                    int RemainingQty = Qty - Recive;
                    con2.Open();
                    SqlCommand cmd2 = new SqlCommand("UpdateQtyInJobSheets", con2);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd2.Parameters.AddWithValue("@jobno", JobNo);
                    cmd2.Parameters.AddWithValue("@salesId", salesNo);
                    cmd2.Parameters.AddWithValue("@RemQty", RemainingQty);
                    cmd2.Parameters.AddWithValue("@procode", ProductCode);
                    cmd2.Parameters.AddWithValue("@bomno", BomNo);
                    int _Ids = Convert.ToInt32(cmd2.ExecuteScalar());

                }

            }
            
            catch (Exception re)
            {

            }

        }

        [HttpGet]
        public int GetIssueQtyFromMIS(string jobno,string code)
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            {
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("sp_getIssuedQty", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@jobno",jobno);
                cmd1.Parameters.AddWithValue("@code", code);
                int Qty = Convert.ToInt32(cmd1.ExecuteScalar());
                 
                return Qty;
            }
        }

        [HttpGet]
        public int GetQtyFromStock(string code)
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            {
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("sp_getStockQtyFromRMByCode", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure; 
                cmd1.Parameters.AddWithValue("@code", code);
                int Qty = Convert.ToInt32(cmd1.ExecuteScalar());

                return Qty;
            }
        }
        
        public int UpdateUpdatedQtyInSalesOrder(string procode, string salesOrder, int updateQty)
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            {
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("UpdateQtyToProduceInSalesOrder", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@ProductCode", procode);
                cmd1.Parameters.AddWithValue("@salesOrder", salesOrder);
                cmd1.Parameters.AddWithValue("@qty", updateQty);
                int Qty = Convert.ToInt32(cmd1.ExecuteScalar());

                return Qty;
            }
        }

        public int UpdateIssueQty(string procode, string jobNo, int updateQty)
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            {
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("sp_UpdateIssuedQty", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@jobno", jobNo);
                cmd1.Parameters.AddWithValue("@code", procode);
                cmd1.Parameters.AddWithValue("@qty", updateQty);
                int Qty = Convert.ToInt32(cmd1.ExecuteScalar());
                return Qty;
            }
        }
    }
}