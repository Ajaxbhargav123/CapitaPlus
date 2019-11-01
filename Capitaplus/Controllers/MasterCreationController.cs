using Capitaplus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capitaplus.Controllers
{
    public class MasterCreationController : Controller
    {
        private CapitaplusEntities _capitaContext;

        public MasterCreationController()
        {
            _capitaContext = new CapitaplusEntities();
        }
        // GET: MasterCreation Brand
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(ProductMaster proMaster)
        {
            string message = "Saved Succesfull";
            bool status = true;
            var getRm = _capitaContext.ProductMasters.ToList();
            foreach (var item in getRm)
            {
                if (item.ProductName.Trim().ToLower() == proMaster.ProductName.Trim().ToLower())
                {
                    return View("CustomerExist");
                }
            } 

            if (proMaster.Id == 0)
            {
                _capitaContext.ProductMasters.Add(proMaster);

            }
            else
            {
                var vendorIbDB = _capitaContext.ProductMasters.Single(v => v.Id == proMaster.Id);

                vendorIbDB.ProductName = proMaster.ProductName;
                vendorIbDB.ShortCode = proMaster.ShortCode; 
            }

            _capitaContext.SaveChanges();
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
            return RedirectToAction("CreateProduct", "MasterCreation");
        }
        public ActionResult ProductList()
        {
            var proList = _capitaContext.ProductMasters.ToList();
            return View(proList);
        }

        public ActionResult ProductEdit(int id)
        {
            var vendorEdit = _capitaContext.ProductMasters.SingleOrDefault(v => v.Id == id);
             
            if (vendorEdit == null)
                return HttpNotFound();

            return View("CreateProduct", vendorEdit);
        }


        // GET: MasterCreation CellType
        public ActionResult CreateCellType()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCell(CellTypeMaster cellMaster)
        {
            
            var getRm = _capitaContext.CellTypeMasters.ToList();
            foreach (var item in getRm)
            {
                if (item.CellType.Trim().ToLower() == cellMaster.CellType.Trim().ToLower())
                {
                    return View("CustomerExist");
                }
            }

            if (cellMaster.Id == 0)
            {
                _capitaContext.CellTypeMasters.Add(cellMaster);

            }
            else
            {
                var vendorIbDB = _capitaContext.CellTypeMasters.Single(v => v.Id == cellMaster.Id);

                vendorIbDB.CellType = cellMaster.CellType; 
            }

            _capitaContext.SaveChanges();
            return RedirectToAction("CreateCellType", "MasterCreation");
        }
        public ActionResult cellList()
        {
            var proList = _capitaContext.CellTypeMasters.ToList();
            return View(proList);
        }

        public ActionResult CellEdit(int id)
        {
            var cellEdit = _capitaContext.CellTypeMasters.SingleOrDefault(v => v.Id == id);

            if (cellEdit == null)
                return HttpNotFound();

            return View("CreateCellType", cellEdit);
        }
    }
}