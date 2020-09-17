using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTest.Helpers;
using TechTest.Models;
using Xamarin.Forms;

namespace TechTest.ViewModels
{
	public class HomeViewModel : BaseViewModel //: INotifyPropertyChanged
    {
        // readonly IList<MovieBase> source;
        readonly ICPFeeds cpFeeds;

        public ObservableCollection<MovieBase> _MoviesTop;
        public ObservableCollection<MovieBase> MoviesTop
        {
            set { _MoviesTop = value; OnPropertyChanged("MoviesTop"); }
            get { return _MoviesTop; }
        }

        public ObservableCollection<MovieBase> _FilterMoviesTop;
        public ObservableCollection<MovieBase> FilterMoviesTop
        {
            set { _FilterMoviesTop = value; OnPropertyChanged("FilterMoviesTop"); }
            get { return _FilterMoviesTop; }
        }

      
        public ObservableCollection<MovieBase> _MoviesUpcoming;
        public ObservableCollection<MovieBase> MoviesUpcoming
        {
            set { _MoviesUpcoming = value; OnPropertyChanged("MoviesUpcoming"); }
            get { return _MoviesUpcoming; }
        }

        public ObservableCollection<MovieBase> _FilterMoviesUpcoming;
        public ObservableCollection<MovieBase> FilterMoviesUpcoming
        {
            set { _FilterMoviesUpcoming = value; OnPropertyChanged("FilterMoviesUpcoming"); }
            get { return _FilterMoviesUpcoming; }
        }


        public ObservableCollection<MovieBase> _MoviesPopular;
        public ObservableCollection<MovieBase> MoviesPopular
        {
            set { _MoviesPopular = value; OnPropertyChanged("MoviesPopular"); }
            get { return _MoviesPopular; }
        }

        public ObservableCollection<MovieBase> _FilterMoviesPopular;
        public ObservableCollection<MovieBase> FilterMoviesPopular
        {
            set { _FilterMoviesPopular = value; OnPropertyChanged("FilterMoviesPopular"); }
            get { return _FilterMoviesPopular; }
        }



        private bool _IsVisiblestk1 = true;
        public bool IsVisiblestk1
        {
            get { return _IsVisiblestk1; }
            set { SetProperty(ref _IsVisiblestk1, value); }
        }

        private bool _IsVisiblestk2 = true;
        public bool IsVisiblestk2
        {
            get { return _IsVisiblestk2; }
            set { SetProperty(ref _IsVisiblestk2, value); }
        }

        private bool _IsVisiblestk3 = true;
        public bool IsVisiblestk3
        {
            get { return _IsVisiblestk3; }
            set { SetProperty(ref _IsVisiblestk3, value); }
        }

		private int _Currentitem = 4;
		public int Currentitem
        {
			get { return _Currentitem; }
			set { SetProperty(ref _Currentitem, value); }
		}
		//private string _IsVisibleMessageText = "";
		//public string IsVisibleMessageText
		//{
		//    get { return _IsVisibleMessageText; }
		//    set { SetProperty(ref _IsVisibleMessageText, value); }
		//}



		public ObservableCollection<MovieBase> Movies2 { get; private set; }


        public ObservableCollection<MovieBase> Movies2Filter { get; private set; }


        public HomeViewModel()
        {
            this.cpFeeds = DependencyService.Get<ICPFeeds>();
            CreatellectionAsync();
        }

        async Task CreatellectionAsync()
        {
            try
            {
                MovieBase Movies_top_rated = new MovieBase();
            
                Movies_top_rated = await cpFeeds.GetMovies("top_rated", "1");
               
                MoviesTop = new ObservableCollection<MovieBase>();
                FilterMoviesTop = new ObservableCollection<MovieBase>();

                for (int a = 0; a < 10; a++)
                {

                    MoviesTop.Add(new MovieBase
                    {
                        Name = Movies_top_rated.results[a].original_title,
                        ImageUrl = "https://image.tmdb.org/t/p/w500/" + Movies_top_rated.results[a].poster_path,
                        ID = Movies_top_rated.results[a].id,
                        IsVisibleStar = true,
                        overview = Movies_top_rated.results[a].overview
                    }); ;

				}
                FilterMoviesTop = MoviesTop;
                
                Movies_top_rated = await cpFeeds.GetMovies("upcoming", "1");

                MoviesUpcoming = new ObservableCollection<MovieBase>();
                FilterMoviesUpcoming = new ObservableCollection<MovieBase>();
                for (int a = 0; a < 10; a++)
                {

                    MoviesUpcoming.Add(new MovieBase
                    {
                        Name = Movies_top_rated.results[a].original_title,
                        ImageUrl = "https://image.tmdb.org/t/p/w500/" + Movies_top_rated.results[a].poster_path,
                        ID = Movies_top_rated.results[a].id,
                        IsVisibleStar = true,
                        overview = Movies_top_rated.results[a].overview
                    });

                }
                FilterMoviesUpcoming = MoviesUpcoming;


                Movies_top_rated = await cpFeeds.GetMovies("popular", "1");

                MoviesPopular = new ObservableCollection<MovieBase>();
                FilterMoviesPopular = new ObservableCollection<MovieBase>();
                for (int a = 0; a < 10; a++)
                {

                    MoviesPopular.Add(new MovieBase
                    {
                        Name = Movies_top_rated.results[a].original_title,
                        ImageUrl = "https://image.tmdb.org/t/p/w500/" + Movies_top_rated.results[a].poster_path,
                        ID = Movies_top_rated.results[a].id,
                        IsVisibleStar = true,
                        overview = Movies_top_rated.results[a].overview
                    });

                }
                FilterMoviesPopular = MoviesPopular;

                Currentitem = 4;
            }
            catch (Exception e)
            {
                string ee = e.Message;
            }
        }

        internal void FilterItemsName(string v)
        {
         
           
            if (v.Length == 0)
            {
                FilterMoviesTop = MoviesTop;
                FilterMoviesUpcoming = MoviesUpcoming;
                FilterMoviesPopular = MoviesPopular;

                IsVisiblestk1 = true;
                IsVisiblestk2 = true;
                IsVisiblestk3 = true;

            }
            else
            {
                FilterMoviesTop = new ObservableCollection<MovieBase>(MoviesTop.Where(ps => ps.Name.ToUpper().Contains(v.ToUpper())));
                IsVisiblestk1 = FilterMoviesTop.Count==0?false:true; 
                FilterMoviesUpcoming = new ObservableCollection<MovieBase>(MoviesUpcoming.Where(ps => ps.Name.ToUpper().Contains(v.ToUpper())));
                IsVisiblestk2 = FilterMoviesUpcoming.Count == 0 ? false : true; 
                FilterMoviesPopular = new ObservableCollection<MovieBase>(MoviesPopular.Where(ps => ps.Name.ToUpper().Contains(v.ToUpper())));
                IsVisiblestk3 = FilterMoviesPopular.Count == 0 ? false : true;

                if (!IsVisiblestk1 && !IsVisiblestk2 && !IsVisiblestk3) {

                    ObservableCollection<MovieBase> oerror = new ObservableCollection<MovieBase>();

                    oerror.Add(new MovieBase { Name = "No se encontraron resultados", IsVisibleStar=false });

                    IsVisiblestk1 = true;
                    FilterMoviesTop = oerror;
                    IsVisiblestk2 = true;
                    FilterMoviesUpcoming = oerror;
                    IsVisiblestk3 = true;
                    FilterMoviesPopular = oerror;

               
                }
            }

            Currentitem = 4;
            //if (rrr.Count == 0)
            //{
            //    IsVisibleMessageText = "Empresa no encontrada..." + v;
            //    IsVisibleMessage = true;
            //}
            //else
            //{
            //    IsVisibleMessageText = "";
            //    IsVisibleMessage = false;
            //}

            //Items = rrr;
        }
    }
}
