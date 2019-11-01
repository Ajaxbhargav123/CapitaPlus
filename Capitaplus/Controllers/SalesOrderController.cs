using Capitaplus.Models;
using Capitaplus.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq; 
using System.Web.Mvc; 

namespace Capitaplus.Controllers
{
    public class SalesOrderController : Controller
    {
        private CapitaplusEntities _capitaContext;
        public string strConnection = ConfigurationManager.ConnectionStrings["FinalDB"].ConnectionString;
        public int Id = 0;
        public SalesOrderController()
        { 
            _capitaContext = new CapitaplusEntities(); 
        }
        // GET: SalesOrder
        public ActionResult Index()
        {
            var roCreation = _capitaContext.FinishedGoods.ToList();
            var packingType = _capitaContext.MasterPackingTypes.ToList();
            var vmSalesOrder = new SalesOrderVM
            {
                fgGoods = roCreation,
                packingType=packingType
            };
            return View(vmSalesOrder);
        }

        //Create Po
        public ActionResult redirectToSo(int id)
        {
            var soCreation = _capitaContext.FinishedGoods.Where(c => c.StockType.Trim() == "Self").ToList();
            var User = _capitaContext.CustomerMasters.SingleOrDefault(v => v.S_No == id);
            if (User == null)
                return HttpNotFound();

            var salesVM = new SalesOrderVM
            {
                customers=User,
                fgGoods=soCreation
            };
            return View("Index", salesVM);
        }

        //Insert FGStocKItems
        [HttpPost]
        public void Insert(string Code, string ProductlName, string Type, string Capacity, string Color, string Model, int qty, int? QtyToFreez,int FGInStock, int qtyProduce, string Brand, string OrderType, string PaymentType, string credidP, string customerName, string addr, string ConNo,int Cid,string Rate,int TQtyToProduce)
        {
            try
            {
                int _Id = 0;
                Code = Code.Trim();
                ProductlName = ProductlName.Trim();
                Type = Type.Trim();
                Capacity = Capacity.Trim();
                Color = Color.Trim();
                Model = Model.Trim();
                Brand = Model.Trim();

                SqlConnection con = new SqlConnection(strConnection);

                con.Open();
                SqlCommand cmd = new SqlCommand("sp_AddFGStocks", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Code", Code.Trim());
                cmd.Parameters.AddWithValue("@productName", ProductlName.Trim());
               
                cmd.Parameters.AddWithValue("@Color", Color.Trim());
                cmd.Parameters.AddWithValue("@Type", Type.Trim()); 
                cmd.Parameters.AddWithValue("@Capacity_AMH", Capacity.Trim());
                cmd.Parameters.AddWithValue("@Model", Model.Trim());
                cmd.Parameters.AddWithValue("@Qty", Convert.ToInt32(qty)); 
                cmd.Parameters.AddWithValue("@brand", Brand.Trim());
                cmd.Parameters.AddWithValue("@fgInStockt", FGInStock);
                cmd.Parameters.AddWithValue("@qtytopro", qtyProduce);
                cmd.Parameters.AddWithValue("@rate", Rate);
                cmd.Parameters.AddWithValue("@TQtyProduce", TQtyToProduce);
                if (QtyToFreez == null)
                {
                    QtyToFreez = 0;
                }

                cmd.Parameters.AddWithValue("@qtyToFreez", QtyToFreez);
                cmd.Parameters.AddWithValue("@IsFreez", false);

                cmd.Parameters.AddWithValue("@orderType", OrderType.Trim());
                cmd.Parameters.AddWithValue("@PaymentTerm", PaymentType.Trim());
                cmd.Parameters.AddWithValue("@CreditPeriod", credidP);
                cmd.Parameters.AddWithValue("@customerName", customerName.Trim());
                cmd.Parameters.AddWithValue("@Cid", Cid);
                cmd.Parameters.AddWithValue("@Address", addr.Trim());
                cmd.Parameters.AddWithValue("@contactNo",ConNo.Trim());

                _Id = Convert.ToInt32(cmd.ExecuteScalar());


            }
            catch (Exception re)
            {
                //IsSuccess = false;
                //return IsSuccess;
            }
            // return IsSuccess;
        }

        [HttpPost]
        public void UpdateQty(string Code, int qty)
        {
            
            using (SqlConnection con = new SqlConnection(strConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_UpdateQtyInFgStock", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", Code);
                cmd.Parameters.AddWithValue("@qty", qty);
               int Ids = Convert.ToInt32(cmd.ExecuteScalar());
 
            }

             
        }

        [HttpPost]
        public void UpdateQtyInFinishedGoods(string Code, int qty)
        { 
            using (SqlConnection con = new SqlConnection(strConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_UpdateQtyInFinishedFoods", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", Code);
                cmd.Parameters.AddWithValue("@qty", qty);
                int Ids = Convert.ToInt32(cmd.ExecuteScalar()); 
            }
             
        }
        //Update StockTable
        [HttpPost]
        public void UpdateProductInStockTable(string ProductCode, string salesOrderNo,string proserialCode, int cid, int qtyToFreez)
        { 
            try
            {
                using (SqlConnection con = new SqlConnection(strConnection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_UpdateStockInStockTableFromSalesOrder", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@productcode", ProductCode);
                    cmd.Parameters.AddWithValue("@salesNo", salesOrderNo);
                    cmd.Parameters.AddWithValue("@proserialCode", proserialCode);
                    cmd.Parameters.AddWithValue("@cid", cid);
                    cmd.Parameters.AddWithValue("@qtyToUpdate", qtyToFreez);

                    int Ids = Convert.ToInt32(cmd.ExecuteScalar()); 
                }

            }catch(Exception e)
            { 
            } 
        }
         
        //InDropDown
        public string GetFGFromStock(string code)
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            { 
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("sp_getFGBYFGstocks", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                cmd1.Parameters.Add("@json", SqlDbType.NVarChar, -1).Direction = ParameterDirection.Output;
                cmd1.Parameters.AddWithValue("@code", code);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;

                cmd1.ExecuteNonQuery();

                // Get the values
                string json = cmd1.Parameters["@json"].Value.ToString();
                return json;


            }
        }

        // Check The Quantity To Confirm Order
        
        public string GetQty(string code,int id)
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            { 
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("sp_getQtyByCodeId", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure; 
                cmd1.Parameters.AddWithValue("@code", code);
                cmd1.Parameters.AddWithValue("@id", id);  
               string jsons= cmd1.ExecuteScalar().ToString();
                return jsons;


            }
        }

        //InDropDown
        public int GetQtyFromStock()
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            {

                con1.Open();
                SqlCommand cmd1 = new SqlCommand("sp_IsQtyOver", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;

                int value = (int)cmd1.ExecuteScalar();
                return value;
 
            }
        }

        //Insert FinalSales
        [HttpPost]
        public void InsertIntoSales(int pacType, int pacTypeQty, string salesOrderNo, string Code, string ProductlName, string Type, string Capacity, string Color, string Model, string IndividualPacking, int QtyIndividual, string BoxPacking,int BoxQty,int RequierdBox, int Cid,int QtyToProduce,string remark)
        {
            try
            {
                int _Id = 0; 
                SqlConnection con = new SqlConnection(strConnection); 
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_AddSalesOrder", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@productName", ProductlName); 
                cmd.Parameters.AddWithValue("@Color", Color);
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@Capacity_AMH", Capacity);
                cmd.Parameters.AddWithValue("@Model", Model); 
                cmd.Parameters.AddWithValue("@IndivisualPacking", IndividualPacking);
                cmd.Parameters.AddWithValue("@QtyIndivisual",QtyIndividual); 
                cmd.Parameters.AddWithValue("@BoxPacking", BoxPacking);
                cmd.Parameters.AddWithValue("@QtyBox", BoxQty);
                cmd.Parameters.AddWithValue("@ReqBox", RequierdBox);
                cmd.Parameters.AddWithValue("@remark", remark); 
                cmd.Parameters.AddWithValue("@TQtyPro",QtyToProduce ); 
                cmd.Parameters.AddWithValue("@custId", Cid);
                cmd.Parameters.AddWithValue("@pacTypeId", pacType);
                cmd.Parameters.AddWithValue("@pacTypeQty", pacTypeQty);

                cmd.Parameters.AddWithValue("@salesOrderNo",salesOrderNo);
  
                _Id = Convert.ToInt32(cmd.ExecuteScalar());


            }
            catch (Exception re)
            {
            
            }
            
        }
         
        //Insert DeliverySchedule
        [HttpPost]
        public void InsertIntoDeliverySchedule(string salesOrderNo, string Code, string ProductlName, string Type, string Capacity, string Color, string Model,  int qtyDeliver, string deliveryDate, string DeliveryAddress,int Cid)
        {
            try
            {
                int _Id = 0;

                SqlConnection con = new SqlConnection(strConnection);

                con.Open();
                SqlCommand cmd = new SqlCommand("sp_AddDeliverySchedule", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@productName", ProductlName);

                cmd.Parameters.AddWithValue("@Color", Color);
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@Capacity_AMH", Capacity);
                cmd.Parameters.AddWithValue("@Model", Model);
                cmd.Parameters.AddWithValue("@salesOrderNo", "SO000" + salesOrderNo);

                cmd.Parameters.AddWithValue("@DeliveryDate", deliveryDate);
                cmd.Parameters.AddWithValue("@AddressDelivery", DeliveryAddress);
                cmd.Parameters.AddWithValue("@QtyDelivery", qtyDeliver);
              
                
                cmd.Parameters.AddWithValue("@custId", Cid);

                _Id = Convert.ToInt32(cmd.ExecuteScalar());


            }
            catch (Exception re)
            {
                
            }
           
        }
         
        //Insert DeliverySchedule
        [HttpPost]
        public void InsertIntoCustomerSalesOrder(int updatedQtyoProduce, int rate, int qtytopro,int qtytofreez,string salesOrderNo,string OrderType,string paymentTerm,int creditPeriod, string cName,string cAddress,string contactNo,string cPerson, string Code, string ProductlName, string Type, string Capacity, string Color, string Model, string brand, int amt, int totalamt, int grossAmt, int totalgrossAmt, int soQty, int stock, int Cid)
        {
            try
            {
                int _Id = 0; 
                SqlConnection con = new SqlConnection(strConnection); 
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_AddCustomerSalesOrder", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Code", Code);
                cmd.Parameters.AddWithValue("@productName", ProductlName); 
                cmd.Parameters.AddWithValue("@Color", Color);
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@Capacity_AMH", Capacity);
                cmd.Parameters.AddWithValue("@Model", Model);
                cmd.Parameters.AddWithValue("@salesOrderNo", "SO000" + salesOrderNo); 
                cmd.Parameters.AddWithValue("@orderType", OrderType);
                cmd.Parameters.AddWithValue("@PaymentTerm", paymentTerm);
                cmd.Parameters.AddWithValue("@CreditPeriod", creditPeriod); 
                cmd.Parameters.AddWithValue("@customerName", cName);
                cmd.Parameters.AddWithValue("@Address", cAddress);
                cmd.Parameters.AddWithValue("@contactNo", contactNo);
                cmd.Parameters.AddWithValue("@contactPer", cPerson);
                cmd.Parameters.AddWithValue("@brand", brand);
                cmd.Parameters.AddWithValue("@soQty", soQty);
                cmd.Parameters.AddWithValue("@Amount", amt); 
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.Parameters.AddWithValue("@totalAmt", totalamt);
                cmd.Parameters.AddWithValue("@grossAmt", grossAmt);
                cmd.Parameters.AddWithValue("@totalGrossAmt", totalgrossAmt);
                cmd.Parameters.AddWithValue("@qtytofreez", qtytofreez);
                cmd.Parameters.AddWithValue("@qtytoproduce", qtytopro);
                cmd.Parameters.AddWithValue("@rate", rate);
                cmd.Parameters.AddWithValue("@updatedProduceQty", updatedQtyoProduce);
                cmd.Parameters.AddWithValue("@custId", Cid); 

                _Id = Convert.ToInt32(cmd.ExecuteScalar());
                 
            }
            catch (Exception re)
            {

            }

        }

        public void DelFgStock()
        {
            SqlConnection con1 = new SqlConnection(strConnection); 
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("sp_truncateFg", con1);
            cmd1.CommandType = System.Data.CommandType.StoredProcedure;
            int Ids = Convert.ToInt32(cmd1.ExecuteScalar());
        } 

        public ActionResult GetFromStock()
        {
            var fgStocks = _capitaContext.GetAllFromFg().ToList(); 
            if (fgStocks == null) 
                return HttpNotFound();

            return Json(new { Data = fgStocks },JsonRequestBehavior.AllowGet);

        }

        public int GetLastMrsId()
        {
            using (SqlConnection con1 = new SqlConnection(strConnection))
            {
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("sp_getSalesOrderId", con1);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;

                int Id = Convert.ToInt32(cmd1.ExecuteScalar());
                return Id;
            }
        }

    }
}