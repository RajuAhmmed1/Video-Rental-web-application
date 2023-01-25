using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using MyApp.Models;
using MyApp.ViewModel;
using MyApp.Migrations;
using System.Net;

namespace MyApp.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _db;
        public CustomersController()
        {
            _db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }




        // GET: Customers
        public ViewResult Index()
        {
            var customer = _db.Customers.Include(c => c.MembershipType).ToList();
            
            if (User.IsInRole("CanManageMovies"))
                return View("Index",customer);
            else
                return View("ReadOnlyIndex", customer);
           
        }

        public ActionResult New()
        {
            var membershiptypes = _db.MemberShipTypes.ToList();
            var customers = new Customers();
            var viewModel = new CustomerForm
            {
                memberShipTypes = membershiptypes,
                customers = customers
            };
            return View("New", viewModel);
        }
        [HttpPost]
        public ActionResult Create(Customers customers)
        {

            if (!ModelState.IsValid)
            {
                var viewmodel = new CustomerForm
                {
                    customers = customers,
                    memberShipTypes = _db.MemberShipTypes.ToList()
                };
                return View("New", viewmodel);
            }


            if (customers.ID == 0)
            {
                _db.Customers.Add(customers);
            }
            else
            {
                var customer = _db.Customers.Single(c => c.ID == customers.ID);
                TryUpdateModel(customer);
                customer.Name = customers.Name;
                customer.MemberShipTypeId = customers.MemberShipTypeId;
                customer.Birthdate = customers.Birthdate;
                customer.IsSubscribedToNewsletter = customers.IsSubscribedToNewsletter;
            }
            _db.SaveChanges();
            return RedirectToAction("Index", "Customers");

        }

        public ActionResult Edit(int id)
        {
            var customer = _db.Customers.SingleOrDefault(c => c.ID == id);
            if (id == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerForm
            {
                memberShipTypes = _db.MemberShipTypes.ToList(),
                customers = customer
            };
            return View("New", viewModel);
        }
        public ActionResult Delete(int id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers aspInfoStaff = _db.Customers.Find(id);
            if (aspInfoStaff == null)
            {
                return HttpNotFound();
            }
            _db.Customers.Remove(aspInfoStaff);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}