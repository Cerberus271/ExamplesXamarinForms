using App1.Behaviors;
using App1.Cards;
using App1.Carosuel;
using App1.CustomControls;
using App1.GoogleMap;
using App1.Intro;
using App1.Popups;
using App1.RatingControl;
using App1.SocialCard;
using App1.XFDownloadManager;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App1
{
    public partial class App : Application
    {
        public static double ScreenWidth;
        public static double ScreenHeight;
        public App()
        {
            InitializeComponent();


             MainPage = new NavigationPage(new App1.FacebookLogin.LoginFacebook());

            //var navPage = new NavigationPage(new App1.FacebookLogin.Page1());
            //navPage.Navigation.PushAsync(new MainPage());
            //MainPage = navPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
