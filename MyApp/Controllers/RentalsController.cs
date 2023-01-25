using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using MyApp.Models;

using MyApp.Migrations;
using System.Net;

namespace MyApp.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext _db;
        public RentalsController()
        {
            _db = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }


        [HttpGet]
        public ActionResult New()
        {
            var rental = new Rental();
            var movie = _db.Movies.ToList();
            ViewBag.movie = movie;
            var customer = _db.Customers.ToList();
            ViewBag.customer = customer;

            return View(rental);
        }

        [HttpPost]
        public ActionResult New(Rental rental,IList<dynamic>movie)
        {
            if (ModelState.IsValid)
            {

                var BTotal = movie.Count;
                string MovieID;


                var i = 0;
                for (var Bindex = 0; Bindex < BTotal; Bindex++)
                {
                    i = i + 1;
                    MovieID = Convert.ToString(movie[Bindex]);
                    rental.MovieID = MovieID;
                    _db.Rentals.Add(rental);
                    _db.SaveChanges();

                }
                return RedirectToAction("Index");

            }

            var movieinfo = _db.Movies.ToList();
            ViewBag.movie = movieinfo;
            var customer = _db.Customers.ToList();
            ViewBag.customer = customer;

            return View(rental);


        }

        // GET: Rentals
        public ActionResult Index()
        {
            var rental = _db.Rentals.ToList();
         
            return View(rental);
        }

        public ActionResult Delete(int? id)
        {

          
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Rental rental = _db.Rentals.Find(id);
                if (rental == null)
                {
                    return HttpNotFound();
                }
                _db.Rentals.Remove(rental);
                _db.SaveChanges();
                return RedirectToAction("Index");

           

        }

    }
}