using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTest.Helpers;
using TechTest.Models;
using TechTest.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(CPFeedService))]
namespace TechTest.Services
{
	public class CPFeedService : ICPFeeds
	{
		public async Task<MovieCredits> GetCredits(int iMovie)
		{
            MovieCredits oMovieCredits = new MovieCredits();
            try
            {
                wsConexion ws = new wsConexion();
                //Settings.sError = "";

                string sResponse = await ws.GetDataRestAsyncCredits(iMovie);
                oMovieCredits = JsonConvert.DeserializeObject<MovieCredits>(sResponse);
            }
            catch (Exception e)
            {
                //oMovieBase.sError = e.Message;
            }
            return oMovieCredits;
        }

		public async Task<MovieBase> GetMovies(string MovieType, string ApyKey)
		{
            MovieBase oMovieBase = new MovieBase();
            try
            {
                wsConexion ws = new wsConexion();
                //Settings.sError = "";

                string sResponse = await ws.GetDataRestAsync(MovieType);
                oMovieBase = JsonConvert.DeserializeObject<MovieBase>(sResponse);
            }
            catch (Exception e)
            {
                oMovieBase.sError = e.Message;
            }
            return oMovieBase;
        }

		public async Task<MovieDetail> GetMoviesDetail(int iMovie)
		{
            MovieDetail oMovieDetail = new MovieDetail();
            try
            {
                wsConexion ws = new wsConexion();
                //Settings.sError = "";

                string sResponse = await ws.GetDataRestAsync(iMovie.ToString());
                oMovieDetail = JsonConvert.DeserializeObject<MovieDetail>(sResponse);
            }
            catch (Exception e)
            {
                //oMovieDetail.sError = e.Message;
            }
            return oMovieDetail;
        }
	}
}
