using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Popups
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPageRg : ContentPage
	{
        private LoginPopupPage _loginPopup;

        public MainPageRg()
        {
            InitializeComponent();

           _loginPopup = new LoginPopupPage();
        }

        private async void OnOpenPupup(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(_loginPopup);
        }

        private async void OnUserAnimationPupup(object sender, EventArgs e)
        {
            //var page = new UserAnimationPage();
            //await PopupNavigation.Instance.PushAsync(page);
        }

        private async void OnOpenSystemOffsetPage(object sender, EventArgs e)
        {
            //var page = new SystemOffsetPage();

            //await PopupNavigation.Instance.PushAsync(page);
        }

        private async void OnOpenListViewPage(object sender, EventArgs e)
        {
            //var page = new ListViewPage();

            //await PopupNavigation.Instance.PushAsync(page);
        }

    }
}