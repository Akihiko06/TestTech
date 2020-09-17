using System;
using System.Collections.Generic;
using System.Text;

namespace TechTest.Models
{
	public class MovieDetail
	{
		//Estudio
		//GENEROS
		//LANZAMIENTO

		public string release_date { get; set; }
		public Generos[] genres { get; set; }
		public productoras[] production_companies { get; set; } 
	}

	public class Generos{

		public int id { get; set; }
		public string name { get; set; }
	}

	public class productoras {

		public int id { get; set; }
		public string name { get; set; }
	}
}
