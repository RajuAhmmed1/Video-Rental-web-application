using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MyApp.ViewModel;
using System.Web.Mvc;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _db;
        public MoviesController()
        {
            _db = new ApplicationDbContext();
        }



        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }

        // GET: Movies
        public ViewResult Index()
        {
            var movie = _db.Movies.Include(c => c.Genre).ToList();
            if (User.IsInRole("CanManageMovies"))
                return View("Index", movie);
            else
                return View("ReadOnlyIndex", movie);
        }
        [Authorize(Roles ="CanManageMovies")]
        public ActionResult New()
        {
            var genre = _db.Genres.ToList();
            var movie = new Movies();
            var viewModel = new MovieForm
            {
                movies = movie,
                genres = genre
            };
            return View("New", viewModel);
        }

        public ActionResult Create(Movies movies)
        {
            if(!ModelState.IsValid)
            {
                var viewmodel = new MovieForm
                {
                    movies = movies,
                    genres = _db.Genres.ToList()

                };
                return View("New", viewmodel);
            }
            if(movies.Id==0)
            {
                movies.DateAdded = DateTime.Now;
                _db.Movies.Add(movies);
            }
            else
            {
                var movieInDb = _db.Movies.Single(c => c.Id == movies.Id);
                TryUpdateModel(movieInDb);
                movieInDb.Name = movies.Name;
                movieInDb.GenreId = movies.GenreId;
                movieInDb.NumberInStock = movies.NumberInStock;
               movieInDb.ReleaseDate = movies.ReleaseDate;
            }
            _db.SaveChanges();
            return RedirectToAction("Index", "Movies");

        }

        public ActionResult Edit(int id)
        {
            var movie = _db.Movies.SingleOrDefault(c => c.Id == id);
            if(id==null)
            {
                return HttpNotFound();
            }


            var viewModel = new MovieForm
            {
                genres = _db.Genres.ToList(),
                movies = movie
            };
            return View("New", viewModel);
        }
    }
}