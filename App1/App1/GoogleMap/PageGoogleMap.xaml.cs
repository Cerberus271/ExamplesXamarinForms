using Plugin.ExternalMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace App1.GoogleMap
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageGoogleMap : ContentPage
	{
		public PageGoogleMap ()
		{
			InitializeComponent ();

            var position = new Position(37, -122);
            MapView.MoveToRegion( MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1)));
            Pin p = new Pin();
            p.Position = position;
            p.Label = "Holaaa";

            MapView.Pins.Add(p);


        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var success = await CrossExternalMaps.Current.NavigateTo("Xamarin", "av. javier prado", "Lima", "Lima", "", "Peru", "");
        }
    }
}