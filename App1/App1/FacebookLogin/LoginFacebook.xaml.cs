using Newtonsoft.Json.Linq;
using Plugin.FacebookClient;
using Plugin.FacebookClient.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.FacebookLogin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginFacebook : ContentPage
	{
        public delegate void delegateLogin(bool status);
        public event delegateLogin onLoginStatus;

        public LoginFacebook ()
		{
			InitializeComponent ();
            LoginViewModel viewModel = new LoginViewModel();
            viewModel.onLoginStatus += ViewModel_onLoginStatus;          
            BindingContext = viewModel;

        }

        private  void ViewModel_onLoginStatus(bool status)
        {
            if (status)
            {
                onLoginStatus?.Invoke(status);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }


    public class LoginViewModel : INotifyPropertyChanged
    {
        public delegate void delegateLogin(bool status);
        public event delegateLogin onLoginStatus;

        string[] permisions = new string[] { "email", "public_profile", "user_posts" };

        public bool IsBusy { get; set; } = false;
        public bool IsNotBusy { get { return !IsBusy; } }
        public FacebookProfile Profile { get; set; }

        public Command OnLoginCommand { get; set; }
     
        public Command OnLoadDataCommand { get; set; }
        public Command OnLogoutCommand { get; set; }
        public bool IsLoggedIn { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;



        public LoginViewModel()         {

            Profile = new FacebookProfile();

            OnLoginCommand = new Command(async () => await LoginAsync());

            OnLoadDataCommand = new Command(async () => await LoadData());

            OnLogoutCommand = new Command(() =>
            {
                if (CrossFacebookClient.Current.IsLoggedIn)
                {
                    CrossFacebookClient.Current.Logout();
                    IsLoggedIn = false;
                }
            });

        }

        public async Task LoginAsync()         {
            FacebookResponse<bool> response = await CrossFacebookClient.Current.LoginAsync(permisions);             switch (response.Status)
            {
                case FacebookActionStatus.Completed:
                    IsLoggedIn = true;
                    OnLoadDataCommand.Execute(null);
                    break;
                case FacebookActionStatus.Canceled:

                    break;
                case FacebookActionStatus.Unauthorized:
                    await App.Current.MainPage.DisplayAlert("Unauthorized", response.Message, "Ok");
                    break;
                case FacebookActionStatus.Error:
                    await App.Current.MainPage.DisplayAlert("Error", response.Message, "Ok");
                    break;
            }          }

        public async Task LoadData()
        {

            var jsonData = await CrossFacebookClient.Current.RequestUserDataAsync
            (
                  new string[] { "id", "name", "email", "picture", "cover", "friends" }, new string[] { }
            );

            var data = JObject.Parse(jsonData.Data);
            Profile = new FacebookProfile()
            {
                FullName = data["name"].ToString(),
                Picture = new UriImageSource { Uri = new Uri($"{data["picture"]["data"]["url"]}") },
                Email = data["email"].ToString()
            };
           
            onLoginStatus.Invoke(true);

        }


    }
}