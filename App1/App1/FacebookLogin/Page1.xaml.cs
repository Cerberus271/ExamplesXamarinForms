using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.FacebookLogin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var login = new LoginFacebook();
            login.onLoginStatus += Login_onLoginStatus;
            await Navigation.PushModalAsync(login);
        }

        private async void Login_onLoginStatus(bool status)
        {
            if (status)
            {
                await Navigation.PopModalAsync();
                await Task.Delay(2000);
                await Navigation.PushAsync(new Page2());
            }
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("", "Mensaje", "Cancelar"); 
        }
    }
}