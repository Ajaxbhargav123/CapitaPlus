using Capitaplus.Models;
using Capitaplus.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Capitaplus.Controllers
{
    public class CreateCustomerController : Controller
    {
        private CapitaplusEntities _capitaContext;

        public CreateCustomerController()
        {
            _capitaContext = new CapitaplusEntities();
        }
        // GET: CreateCustomer
        public ActionResult Index()
        {
            var custTypes = _capitaContext.CustomerTypes.ToList();
            var SuplierTypes = _capitaContext.SuplierTypes.ToList();
            var viewModelCustomer = new CustomerMasterVM
            {
                supplierTypes = SuplierTypes,
                custTypes=custTypes
                
            };
            return View(viewModelCustomer);
        }

        public ActionResult EditIndex()
        {
            var SuplierTypes = _capitaContext.SuplierTypes.ToList();
            var custTypes = _capitaContext.CustomerTypes.ToList();
            var viewModelCustomer = new CustomerMasterVM
            {
                supplierTypes = SuplierTypes,
               custTypes=custTypes
            };
            return View(viewModelCustomer);
        }


        public ActionResult Edit(CustomerMasterVM customer)
        {
            if (customer.customerMaster.S_No != 0)
            {
                var vendorIbDB = _capitaContext.CustomerMasters.Single(v => v.S_No == customer.customerMaster.S_No);

                vendorIbDB.CustomerName = customer.customerMaster.CustomerName;
                vendorIbDB.CustomerAddress = customer.customerMaster.CustomerAddress;
                vendorIbDB.SuplierGstNo = customer.customerMaster.SuplierGstNo;
                vendorIbDB.SuplierTypeId = customer.customerMaster.SuplierTypeId;
                vendorIbDB.ContactPerson = customer.customerMaster.ContactPerson;
                vendorIbDB.DeliveryFrom = customer.customerMaster.DeliveryFrom;
                vendorIbDB.ContactNo = customer.customerMaster.ContactNo;

            }
            _capitaContext.SaveChanges();
            return RedirectToAction("Index", "CreateCustomer");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustomer(CustomerMasterVM customer)
        {
            if(customer.customerMaster.CustomerName==null || customer.customerMaster.CustomerAddress == null || customer.customerMaster.ContactNo == null || customer.customerMaster.ContactPerson == null)
            {
                return View("_partialView/CustomernotValid");
            }
            var getRm = _capitaContext.CustomerMasters.ToList();
            foreach (var item in getRm)
            {
                if (item.CustomerName.Trim().ToLower() == customer.customerMaster.CustomerName.Trim().ToLower())
                {
                    return View("CustomerExist");
                }
            } 

            if (customer.customerMaster.S_No == 0)
            {
                customer.customerMaster.CustomerCode = customer.customerMaster.CustomerName.Substring(0, 4) + "00" + customer.customerMaster.SuplierGstNo.Substring(0, 3);

                var vendorVM = new CustomerMasterVM
                {
                    customerMaster = customer.customerMaster,
                    supplierTypes = _capitaContext.SuplierTypes.ToList(),
                    custTypes = _capitaContext.CustomerTypes.ToList()
                }; 
                _capitaContext.CustomerMasters.Add(customer.customerMaster);
            }
            else
            {
                var vendorIbDB = _capitaContext.CustomerMasters.Single(v => v.S_No == customer.customerMaster.S_No);

                vendorIbDB.CustomerName = customer.customerMaster.CustomerName; 
                vendorIbDB.CustomerAddress = customer.customerMaster.CustomerAddress; 
                vendorIbDB.SuplierGstNo = customer.customerMaster.SuplierGstNo;
                vendorIbDB.SuplierTypeId = customer.customerMaster.SuplierTypeId;
                vendorIbDB.ContactPerson = customer.customerMaster.ContactPerson;
                vendorIbDB.DeliveryFrom = customer.customerMaster.DeliveryFrom;
            }

            _capitaContext.SaveChanges();
            return RedirectToAction("Index", "CreateCustomer");
        }



        public ActionResult CustomerList()
        {
            var customerList = _capitaContext.CustomerMasters.Include(s => s.SuplierType).ToList();
            return View(customerList);
        }

        public ActionResult CustomerEdit(int id)
        {
            var custEdit = _capitaContext.CustomerMasters.SingleOrDefault(v => v.S_No == id);
            if (custEdit == null)
                return HttpNotFound();

            var vendorVM = new CustomerMasterVM
            {
                customerMaster = custEdit,
                supplierTypes = _capitaContext.SuplierTypes.ToList()
            };
            return View("EditIndex", vendorVM);
        }
    }
}