using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTest.Helpers;
using TechTest.Models;
using Xamarin.Forms;

namespace TechTest.ViewModels
{
	public class DetailViewModel : BaseViewModel
	{
		readonly ICPFeeds cpFeeds;

		private string _Studio = "";
		public string Studio
		{
			get { return _Studio; }
			set { SetProperty(ref _Studio, value); }
		}

		private string _Date = "";
		public string Date
		{
			get { return _Date; }
			set { SetProperty(ref _Date, value); }
		}

		private string _Genero = "";
		private StackLayout stkContentCredits;

		public string Genero
		{
			get { return _Genero; }
			set { SetProperty(ref _Genero, value); }
		}

		public DetailViewModel(int iMovie) {
			this.cpFeeds = DependencyService.Get<ICPFeeds>();
			GetData(iMovie);
		}

	

		private async void GetData(int iMovie)
		{
			MovieDetail oMovieDetail = new MovieDetail();
			oMovieDetail  = await cpFeeds.GetMoviesDetail(iMovie);

			Date = oMovieDetail.release_date;

			string St = "";
			for (int r = 0; r < oMovieDetail.production_companies.Length; r++)
			{

				St += oMovieDetail.production_companies[r].name;
				if (r < 3)
				{
					St += ",";
				}

			}
			Studio = St;

			string Gn = "";
			for (int rr = 0; rr < oMovieDetail.genres.Length; rr++)
			{

				Gn += oMovieDetail.genres[rr].name;
				if (rr < 3)
				{
					Gn += ",";
				}
			}
			Genero = Gn;


			
		}

		public MovieCredits oMovieCredits;
		public async Task GetCredits(int iMovie) {

			oMovieCredits = new MovieCredits();

			oMovieCredits = await cpFeeds.GetCredits(iMovie);



		}
	}
}
