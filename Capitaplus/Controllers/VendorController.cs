using Capitaplus.Models;
using Capitaplus.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace Capitaplus.Controllers
{
    public class VendorController : Controller
    {
        private CapitaplusEntities _capitaContext;

        public VendorController()
        {
            _capitaContext = new CapitaplusEntities();
        }
        // GET: Vendor
        public ActionResult CreateVendor()
        { 
            var SuplierTypes = _capitaContext.SuplierTypes.ToList();
            var viewModelVendor = new VendorMasterModel
            {
                supplierTypes = SuplierTypes
            };
            return View(viewModelVendor);
        }

        public ActionResult EditVendor()
        {
            var SuplierTypes = _capitaContext.SuplierTypes.ToList();
            var viewModelVendor = new VendorMasterModel
            {
                supplierTypes = SuplierTypes
            };
            return View(viewModelVendor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult CreateVendor(VendorMasterModel vendor)
        {
            var getRm = _capitaContext.VendorMasters.ToList();
            foreach (var item in getRm)
            {
                if (item.VendorName.Trim().ToLower() == vendor.vendorMaster.VendorName.Trim().ToLower())
                {
                    return View("VendorExist");
                }
            }


            if (vendor.vendorMaster.S_No == 0)
            {
                vendor.vendorMaster.VendorCode = vendor.vendorMaster.VendorName.Substring(0, 4) + "00" + vendor.vendorMaster.SuplierGstNo.Substring(0, 3);
                    var vendorVM = new VendorMasterModel
                    {
                        vendorMaster = vendor.vendorMaster,
                        supplierTypes = _capitaContext.SuplierTypes.ToList()
                    };
                    
                    _capitaContext.VendorMasters.Add(vendor.vendorMaster); 
            }
            else
            {
                var vendorIbDB = _capitaContext.VendorMasters.Single(v => v.S_No == vendor.vendorMaster.S_No);
                vendor.vendorMaster.VendorCode = vendor.vendorMaster.VendorName.Substring(0, 4) + "00" + vendor.vendorMaster.SuplierGstNo.Substring(0, 3);
                vendorIbDB.VendorName = vendor.vendorMaster.VendorName;
                vendorIbDB.VendorCode = vendor.vendorMaster.VendorCode;
                vendorIbDB.VendorAddress = vendor.vendorMaster.VendorAddress; 
                vendorIbDB.SuplierGstNo = vendor.vendorMaster.SuplierGstNo;
                vendorIbDB.SuplierTypeId = vendor.vendorMaster.SuplierTypeId;
                vendorIbDB.ContactPerson = vendor.vendorMaster.ContactPerson;
                
            }
           
            _capitaContext.SaveChanges();
            return  RedirectToAction("CreateVendor", "Vendor");
        }

        public ActionResult VendorList()
        {
            var VendorList = _capitaContext.VendorMasters.Include(s=>s.SuplierType).ToList();
            return View(VendorList);
        }

        public ActionResult VendorDetails(int id)
        {
            var VendorList = _capitaContext.VendorMasters.FirstOrDefault(v => v.S_No == id);
            if (VendorList == null)
                return HttpNotFound();
            return View(VendorList);
        }

        public ActionResult VendorEdit(int id)
        {
            var vendorEdit = _capitaContext.VendorMasters.SingleOrDefault(v => v.S_No == id);
            if (vendorEdit == null)
                return HttpNotFound();

            var vendorVM = new VendorMasterModel
            {
                vendorMaster = vendorEdit,
                supplierTypes = _capitaContext.SuplierTypes.ToList()
            };
            return View("EditVendor", vendorVM);
        }

        public ActionResult Edit(VendorMasterModel vendor)
        {
            if (vendor.vendorMaster.S_No != 0)
            {
                var vendorIbDB = _capitaContext.VendorMasters.Single(v => v.S_No == vendor.vendorMaster.S_No);
                vendor.vendorMaster.VendorCode = vendor.vendorMaster.VendorName.Substring(0, 4) + "00" + vendor.vendorMaster.SuplierGstNo.Substring(0, 3);
                vendorIbDB.VendorName = vendor.vendorMaster.VendorName;
                vendorIbDB.VendorCode = vendor.vendorMaster.VendorCode;
                vendorIbDB.VendorAddress = vendor.vendorMaster.VendorAddress;
                vendorIbDB.SuplierGstNo = vendor.vendorMaster.SuplierGstNo;
                vendorIbDB.SuplierTypeId = vendor.vendorMaster.SuplierTypeId;
                vendorIbDB.ContactPerson = vendor.vendorMaster.ContactPerson;
                vendorIbDB.ContactNo = vendor.vendorMaster.ContactNo;

            }
            _capitaContext.SaveChanges();
            return RedirectToAction("CreateVendor", "Vendor");
        }
    }
}