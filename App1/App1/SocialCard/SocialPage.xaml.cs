using App1.Cards;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.SocialCard
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SocialPage : ContentPage
	{
		public SocialPage ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var popup = new PopupBusyPage();
            popup.CloseWhenBackgroundIsClicked = false;
            await PopupNavigation.Instance.PushAsync(popup, true);

            await Task.Delay(3000);

            await PopupNavigation.Instance.PopAllAsync(true);
        }
    }
}