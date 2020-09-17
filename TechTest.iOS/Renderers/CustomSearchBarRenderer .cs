using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using TechTest.iOS.Renderers;
using TechTest.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBarRenderer))]
namespace TechTest.iOS.Renderers
{
	public class CustomSearchBarRenderer : SearchBarRenderer
    {
        #region Properties

        private UIColor BorderColor = UIColor.Black;

        private int BorderWidth = 1;

        #endregion

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            var newElement = ((CustomSearchBar)e.NewElement);

            BorderColor = newElement.BorderColor.ToUIColor();

            if (newElement.BorderWidth != 0)
            {
                BorderWidth = newElement.BorderWidth;
            }

            var searchbar = (UISearchBar)Control;

            if (e.NewElement != null)
            {
				Foundation.NSString _searchField = new Foundation.NSString("searchField");
				var textFieldInsideSearchBar = (UITextField)searchbar.ValueForKey(_searchField);
				textFieldInsideSearchBar.BackgroundColor = UIColor.FromRGB(255, 255, 255);
				textFieldInsideSearchBar.TextColor = UIColor.Gray;
				searchbar.Layer.BackgroundColor = UIColor.White.CGColor;
                searchbar.TintColor = UIColor.Black;
                searchbar.BarTintColor = UIColor.White;
                searchbar.Layer.CornerRadius = 10;
                searchbar.Layer.BorderWidth = BorderWidth;
                searchbar.Layer.BorderColor = BorderColor.CGColor;

                //searchbar.ShowsCancelButton = false;
            }
        }
    }
}