using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTest.Models;

namespace TechTest.Helpers
{
	interface ICPFeeds
	{
		Task<MovieBase> GetMovies(string MovieType, string ApyKey);
		Task<MovieDetail> GetMoviesDetail(int iMovie);
		Task<MovieCredits> GetCredits(int iMovie);
	}
}
