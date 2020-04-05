using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly1.Models
{
	public class Movie
	{
		public int Id { get; set; }

		[Required]
		[StringLength(250)]
		public string Name { get; set; }

		[Required]
		public byte GenreId { get; set; }

		public Genre Genre { get; set; }

		[Required]
		public DateTime ReleaseDate { get; set; }

		[Required]
		public DateTime DateAdded { get; set; }

		[Required]
		public int NumberInStock { get; set; }
	}
}