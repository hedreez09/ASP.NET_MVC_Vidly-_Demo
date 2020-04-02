using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly1.Models
{
	public class Genre
	{
		public byte GenreId { get; set; }

		[Required]
		public string Name { get; set; }
		
	}
}