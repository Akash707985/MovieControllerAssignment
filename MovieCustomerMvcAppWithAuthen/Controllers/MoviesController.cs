using MovieCustomerMvcAppWithAuthen.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieCustomerMvcAppWithAuthen.ViewModel;

namespace MovieCustomerMvcAppWithAuthen.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(g => g.Genre).ToList();
            return View(movies);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                GenreType=genres
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel(movie)
                {
                    GenreType = _context.Genres.ToList()
                };
            return View("Create", viewModel);
            }
            if(movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {

            }
          
           
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new NewMovieViewModel(movie)
            {
                //Id = movie.Id,
                //Name = movie.Name,
                //GenreId = movie.GenreId,
                GenreType = _context.Genres.ToList()
            };
            return View("Create", viewModel);
        }
        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}