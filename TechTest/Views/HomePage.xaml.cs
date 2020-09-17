using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTest.Models;
using TechTest.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechTest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		HomeViewModel oHomeViewModel;
		public HomePage()
		{
			InitializeComponent();

			BindingContext = oHomeViewModel =  new HomeViewModel();
		}

		async void OnTapped(object sender, EventArgs e)
		{
			//DisplayAlert("info", "Peli", "ok");
			//MovieBase val = ((MovieBase))e;
			var args = (TappedEventArgs)e;
			var myObject = (MovieBase)args.Parameter;

			await Navigation.PushModalAsync(new DetailPage(myObject));
		}

		private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
		{
			try
			{
				if (e.NewTextValue == null)
				{
					oHomeViewModel.FilterItemsName("");
				}
				else
				{
					SearchBar searchBar = (SearchBar)sender;
					if (searchBar.Text.Length >= 3)
					{
						//DisplayAlert("filtrar", "pelicula", "ok");
						oHomeViewModel.FilterItemsName(searchBar.Text);

					}
					else
					{

						if (searchBar.Text.Length == 0)
						{
							//DisplayAlert("RESETEAR", "pelicula", "ok");
							oHomeViewModel.FilterItemsName(searchBar.Text);
						}
					}
				}
			}
			catch { 
			
			}

		}
	}
}