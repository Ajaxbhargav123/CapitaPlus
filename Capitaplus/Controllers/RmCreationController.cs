using Capitaplus.Models;
using Capitaplus.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capitaplus.Controllers
{
    public class RmCreationController : Controller
    {
        private CapitaplusEntities _capitaContext;
             
        public RmCreationController()
        {
            _capitaContext = new CapitaplusEntities();
        }
        // GET: RmCreation
        public ActionResult Index()
        {
            var statuslist = _capitaContext.StatusYesNoes.ToList();
            var status = new RMCreationWithCodeVM
            {
                isYesNos = statuslist
            };
            return View(status);
        }

        public ActionResult EditIndex()
        { 
            return View();
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRM(RMCreationWithCodeVM rmCreations)
        {
            if (rmCreations.rmCreation.MaterialName==null || rmCreations.rmCreation.MaterialGroup == null || rmCreations.rmCreation.Color == null || rmCreations.rmCreation.Model == null || rmCreations.rmCreation.Rate == null || rmCreations.rmCreation.QUOM == null || rmCreations.rmCreation.UOM_1 == null || rmCreations.rmCreation.UOM_2 == null || rmCreations.rmCreation.Type == null || rmCreations.rmCreation.SAC_CODE == null || rmCreations.rmCreation.Stock == null)
            {
                return View("_partialView/AllFiledInRM");
            }
            if (rmCreations.isYesNo.Type == "1")
            {
                rmCreations.rmCreation.IsMinMax = "Yes";
            }
            if (rmCreations.isYesNo.Type == "2")
            {
                rmCreations.rmCreation.IsMinMax = "No";
            }
            else if(rmCreations.isYesNo.Type == "0")
            {
                throw new Exception("Invalid Selection");
            }

            rmCreations.rmCreation.UpdatedStock = rmCreations.rmCreation.Stock;
            if (rmCreations.rmCreation.Capacity_AMH == null)
            {
                rmCreations.rmCreation.Capacity_AMH = "0";
            }
            var getRm = _capitaContext.RoleMaterialCreations.ToList();
           
            foreach (var item in getRm)
            {
         
                if (item.MaterialName.Trim().ToLower() == rmCreations.rmCreation.MaterialName.Trim().ToLower() && item.Model.Trim().ToLower()==rmCreations.rmCreation.Model.Trim().ToLower() && item.Type.Trim().ToLower()==rmCreations.rmCreation.Type.Trim().ToLower() && item.Capacity_AMH.Trim().ToLower()==rmCreations.rmCreation.Capacity_AMH.Trim().ToLower() && item.Color.Trim().ToLower()==rmCreations.rmCreation.Color.Trim().ToLower())
                {
                    return View("View");
                }
            } 
            //int cap = Convert.ToInt32(rmCreations.rmCreation.Capacity_AMH);
            //if (Math.Abs(cap) > 999)
            //{
            //    rmCreations.rmCreation.Capacity_AMH = Math.Sign(cap) * (Math.Abs(cap) / 1000) + "k";
            //}
            rmCreations.rmCreation.Code = rmCreations.rmCreation.MaterialName.ToUpper() + rmCreations.rmCreation.Model.ToUpper() + rmCreations.rmCreation.Type.ToUpper() + rmCreations.rmCreation.Color.ToUpper() + rmCreations.rmCreation.Capacity_AMH;
           
            _capitaContext.RoleMaterialCreations.Add(rmCreations.rmCreation);
            _capitaContext.SaveChanges();
            return RedirectToAction("Index", "RmCreation");
        }

        public ActionResult RmEdit(int id)
        {
            var vendorEdit = _capitaContext.RoleMaterialCreations.SingleOrDefault(v => v.Id == id);
            

            var viewModelRM = new RMCreationWithCodeVM
            {
                rmCreation=vendorEdit,
                 
            }; 

            if (vendorEdit == null)
                return HttpNotFound(); 
           
            return View("EditIndex", viewModelRM);
        }

        public ActionResult Edit(RMCreationWithCodeVM rmCreations)
        {
            if (rmCreations.rmCreation.Id != 0)
            {
                var vendorIbDB = _capitaContext.RoleMaterialCreations.Single(v => v.Id == rmCreations.rmCreation.Id);
                rmCreations.rmCreation.Code = rmCreations.rmCreation.MaterialName.ToUpper() + rmCreations.rmCreation.Model.ToUpper() + rmCreations.rmCreation.Type.ToUpper() + rmCreations.rmCreation.Color.ToUpper() + rmCreations.rmCreation.Capacity_AMH;

                vendorIbDB.MaterialName = rmCreations.rmCreation.MaterialName;
                vendorIbDB.MaterialGroup = rmCreations.rmCreation.MaterialGroup;
                vendorIbDB.Capacity_AMH = rmCreations.rmCreation.Capacity_AMH;
                vendorIbDB.Color = rmCreations.rmCreation.Color;
                vendorIbDB.Model = rmCreations.rmCreation.Model;
                vendorIbDB.QUOM = rmCreations.rmCreation.QUOM;
                vendorIbDB.Rate = rmCreations.rmCreation.Rate;

            }
            _capitaContext.SaveChanges();
            return RedirectToAction("CreateVendor", "Vendor");
        }

        public ActionResult RmList()
        {
            var RmList = _capitaContext.RoleMaterialCreations.ToList();
            return View(RmList);
        }
    }
}