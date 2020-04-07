using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly1.Dtos;
using Vidly1.Models;

namespace Vidly1.Controllers.Api
{

	public class MoviesApiController : ApiController
    {
		private ApplicationDbContext _context; 

			public MoviesApiController()
		{
			_context = new ApplicationDbContext();	
		}

		//Get /api/Movies
		public IEnumerable<MovieDto> GetMovies()
		{
			return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
		}

		//Get /api/Movie/1
		public IHttpActionResult GetMovies(int id)
		{
			var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

			if (movie == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			return Ok(Mapper.Map<Movie, MovieDto>(movie));
		}

		//Post/Api/Movie/id
		[HttpPost]
		public IHttpActionResult CreateMovie(MovieDto movieDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var movie = Mapper.Map<MovieDto, Movie>(movieDto);
			_context.Movies.Add(movie);
			_context.SaveChanges();

			movieDto.Id = movie.Id;
			return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
		}
	}
}

