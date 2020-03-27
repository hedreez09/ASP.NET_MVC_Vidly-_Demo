﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly1.Models;
using Vidly1.ViewModels;

namespace Vidly1.Controllers
{
    public class MoviesController : Controller
    {
		// GET: Movies
		
			public ViewResult Random()
			{
				var movies = GetMovies();

				return View(movies);
			}

			private IEnumerable<Movie> GetMovies()
			{
				return new List<Movie>
			{
				new Movie { Id = 1, Name = "Shrek" },
				new Movie { Id = 2, Name = "Wall-e" }
			};
			}
	}
}