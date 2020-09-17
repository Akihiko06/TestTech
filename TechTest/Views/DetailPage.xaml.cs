using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TechTest.Models;
using TechTest.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechTest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{
		private MovieBase myObject;

		DetailViewModel oDetailViewModel;

		public DetailPage()
		{
			InitializeComponent();
			
		}

		public DetailPage(MovieBase myObject)
		{
			InitializeComponent();
			this.myObject = myObject;

			ImgTitle.Source = myObject.ImageUrl;
			overview.Text = myObject.overview;
			Titulo.Text = myObject.Name;

			BindingContext = oDetailViewModel = new DetailViewModel(myObject.ID);

			GeCreditsAsync(myObject.ID);
		}

		private async void GeCreditsAsync(int iMovie)
		{

			await oDetailViewModel.GetCredits(iMovie);

			ScrollView oScrollview = new ScrollView();
			oScrollview.Orientation = ScrollOrientation.Horizontal;
			StackLayout oContetMain = new StackLayout();
			oContetMain.Orientation = StackOrientation.Horizontal;
			for (int a = 0; a < oDetailViewModel.oMovieCredits.cast.Length; a++)
			{
				if (a <= 10)
				{
					Image oImage = new Image();
					oImage.Source = "https://image.tmdb.org/t/p/w500" + oDetailViewModel.oMovieCredits.cast[a].profile_path;
					oImage.WidthRequest = 50;
					oImage.HeightRequest = 50;
					oImage.Aspect = Aspect.Fill;

					Frame oFrame = new Frame();
					oFrame.CornerRadius = 25;
					oFrame.WidthRequest = 50;
					oFrame.HeightRequest = 50;
					oFrame.Content = oImage;
					oFrame.IsClippedToBounds = true;
					oFrame.Padding = 0;

					Label oLabel = new Label();
					oLabel.Text = oDetailViewModel.oMovieCredits.cast[a].name;
					oLabel.TextColor = Color.White;
					oLabel.WidthRequest = 30;
					oLabel.LineBreakMode = LineBreakMode.TailTruncation;
			

					StackLayout oContet = new StackLayout();
					oContet.Orientation = StackOrientation.Vertical;
					oContet.Margin = new Thickness(10, 0, 10, 0);
					oContet.HeightRequest = 80;

					oContet.Children.Add(oFrame);
					oContet.Children.Add(oLabel);
					oContetMain.Children.Add(oContet);
				}

				
			}

			oScrollview.Content = oContetMain;

			stkContentCredits.Children.Add(oScrollview);
		}

		private async void ImageButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
	}
}