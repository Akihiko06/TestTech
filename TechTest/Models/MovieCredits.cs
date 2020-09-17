using System;
using System.Collections.Generic;
using System.Text;

namespace TechTest.Models
{
	public class MovieCredits
	{
		public int id { get; set; }
		public castings[] cast { get; set; }
	}

	public class castings
	{
		public string name { get; set; }
		public string profile_path { get; set; }
	}
}
