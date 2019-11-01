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
    public class MaterialIssueSlipController : Controller
    {
        private CapitaplusEntities _capitaContext;
        public string strConnection = ConfigurationManager.ConnectionStrings["FinalDB"].ConnectionString;
        public int Id = 0;

        public MaterialIssueSlipController()
        {
            _capitaContext = new CapitaplusEntities();
        }
        // GET: MaterialIssueSlip
        public ActionResult Index()
        {
            var js = _capitaContext.sp_geMatIssueSlip().Where(x=>x.RowsNo==1).ToList();
            var bm = _capitaContext.BillOfMats.ToList();
            var mrs = _capitaContext.MaterialRequsitionSlips.ToList();

            if (js.Count == 0)
                return View("NoIssueSlipView");


            var bj = new matIssueS
            {
                boms = bm,
                jobOrders = js,
                mrss=mrs
            };

            return View(bj);
        }

        public ActionResult GetMrsDetails(string mrs, string date)
        {
            var mrsDetails = _capitaContext.sp_getAllFromMatRequsitionBymrsNo(mrs, date);

            return Json(new JsonResult { Data = mrsDetails }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void InsertIntoMIS(string MrsNno, string jobno, string bobno, string Code, string ProductlName, string Type, string Capacity, string Color, string Model, int QtyInPiece, int YTD,int issueQty, int BalanceQty)
        {
            try
            {
                int _Id = 0;

                SqlConnection con = new SqlConnection(strConnection);
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_AddMatIssueSlip", con);
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

                cmd.Parameters.AddWithValue("@QtyinPiece", QtyInPiece);
                cmd.Parameters.AddWithValue("@ytd", YTD);
                cmd.Parameters.AddWithValue("@balQty", BalanceQty);
                cmd.Parameters.AddWithValue("@issueQty", issueQty);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@mrsno", MrsNno); 
                _Id = Convert.ToInt32(cmd.ExecuteScalar());


            }
            catch (Exception re)
            {

            }

        }

        public void UpdateQtyInMAtReqPlanning(string mrsno, string code, string jobno, string mat, string bom, int misytd, int misqtyissue, int misbalqty)
        {
            try
            {
                using (SqlConnection con2 = new SqlConnection(strConnection))
                {
                    con2.Open();
                    SqlCommand cmd2 = new SqlCommand("sp_updateBalQtyInMRSFromMis", con2);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd2.Parameters.AddWithValue("@jobsno", jobno.Trim());
                    cmd2.Parameters.AddWithValue("@matname", mat.Trim());
                    cmd2.Parameters.AddWithValue("@code", code.Trim());
                    cmd2.Parameters.AddWithValue("@bomNon", bom.Trim());
                    cmd2.Parameters.AddWithValue("@mrsno", mrsno.Trim());
                    cmd2.Parameters.AddWithValue("@misYtd", misytd);
                    cmd2.Parameters.AddWithValue("@misQtyIssue", misqtyissue);
                    cmd2.Parameters.AddWithValue("@misbalQty", misbalqty);


                    int _Id = Convert.ToInt32(cmd2.ExecuteScalar());

                }
            }
            catch(Exception e)
            {

            }
           
        }

        public ActionResult GetDataFromMatRequsition(string mrs)
        {
            var so = _capitaContext.sp_IsdataAddedInMatRequsition(mrs);

            return Json(new JsonResult { Data = so }, JsonRequestBehavior.AllowGet);
        }

        public void UpdateStatus(string code, string jobno, string bomno)
        {
            // Updating Quantity
            using (SqlConnection con2 = new SqlConnection(strConnection))
            {
                con2.Open();
                SqlCommand cmd2 = new SqlCommand("UpdateStatusInSalesOrderFromMatIssueSlip", con2);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;

               
                cmd2.Parameters.AddWithValue("@jonno", jobno);
                cmd2.Parameters.AddWithValue("@bom", bomno);
                cmd2.Parameters.AddWithValue("@status", true);

                int _Id = Convert.ToInt32(cmd2.ExecuteScalar());

            }
        }
        public ActionResult GetDataFromMatRequsitionAll(string mrs)
        {
            var so = _capitaContext.sp_IsdataAddedInMatRequsitionAll(mrs);

            return Json(new JsonResult { Data = so }, JsonRequestBehavior.AllowGet);
        }

        public int GetLastMrsId()
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            {
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("sp_getMislipId", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;

                int Id = Convert.ToInt32(cmd1.ExecuteScalar());
                return Id;
            }
        }

        public int GetQtyFromRawMat(string code)
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            {
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("sp_getStockFromRawMat", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@procode", code);
                int Id = Convert.ToInt32(cmd1.ExecuteScalar());
                return Id;
            }
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
    }
}