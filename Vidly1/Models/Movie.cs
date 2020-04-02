﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly1.Models
{
	public class Movie
	{
		public int Id { get; set; }

		[Required]
		[StringLength(250)]
		public string Name { get; set; }

		public byte GenreId { get; set; }

		[Required]
		public Genre Genre { get; set; }

		public DateTime ReleaseDate { get; set; }

		public DateTime DateAdded { get; set; }

		public int NumberInStock { get; set; }
	}
}