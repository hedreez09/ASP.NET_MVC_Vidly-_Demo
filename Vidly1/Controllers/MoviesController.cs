using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly1.Models;
using System.Data.Entity;
using Vidly1.ViewModels;
using System.Data.Entity.Validation;

namespace Vidly1.Controllers
{
    public class MoviesController : Controller
    {
		private ApplicationDbContext _context;

		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ActionResult New()
		{
			var genres = _context.Genres.ToList();
			var viewModel = new MovieFormViewModel
			{	
				Genres = genres
			};

			return View("MovieForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Movie movie)
		{
			if (!ModelState.IsValid)// this help in getting access to validation data. 
			{
				var viewModel = new MovieFormViewModel(movie)
				{
					
					Genres = _context.Genres.ToList()
					
				};
				return View("MovieForm", viewModel);
			}

			//var ade = Newtonsoft.Json.JsonConvert.SerializeObject(movie);

			if (movie.Id == 0)
				_context.Movies.Add(movie);
			else
			{
				var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

				movieInDb.Name = movie.Name;
				movieInDb.Genre = movie.Genre;
				movieInDb.ReleaseDate = movie.ReleaseDate;
				movieInDb.NumberInStock = movie.NumberInStock;
				movieInDb.DateAdded = movie.DateAdded;
			}



			_context.SaveChanges();
			return RedirectToAction("Index", "Movies");

		}
			// GET: Movies

			public ViewResult Index()
			{

			var movies = _context.Movies.Include(m => m.Genre).ToList();

			return View(movies);
			}

		public ActionResult Details(int id)
		{
			var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

			if (movie == null)
				return HttpNotFound();

			return View(movie);

		}

		public ActionResult Edit(int id)
		{
			var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
			if (movie == null)
				return HttpNotFound();
			var viewModel = new MovieFormViewModel(movie)
			{
				Genres = _context.Genres.ToList()
			};

			return View("MovieForm", viewModel); ;
		}

		public ActionResult DeleteMovie( int id)
		{
			var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
			if (movieInDb == null)
				return HttpNotFound();

			_context.Movies.Remove(movieInDb);
			_context.SaveChanges();

			return RedirectToAction("Index", "Movies");

		}
	}
}