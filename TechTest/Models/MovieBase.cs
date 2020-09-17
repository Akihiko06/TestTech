using System;
using System.Collections.Generic;
using System.Text;

namespace TechTest.Models
{
	public class MovieBase
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public string Name { get; set; }
		public string ImageUrl { get; set; }
		public string sError { get; set; }
		public string page { get; set; }
		public string total_results { get; set; }
		public string overview { get; set; }
		public string total_pages { get; set; }
		public Movie[] results { get; set; }
		public bool IsVisibleStar { get; set; }
	}

	public class Movie {
		public string original_title { get; set; }
		public int id { get; set; }
		public string poster_path { get; set; }
		public string overview { get; set; }
	}
}
